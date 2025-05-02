using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using TMBack.Interfaces.Auth;
using TMBack.Interfaces.Repositories;
using TMBack.Models;
using TMBack.Contracts.User;
using TMBack.Repositories;

namespace TMBack.Services;

public class UsersService
{
    private readonly IPasswordHasher _passwordHasher;

    private readonly TaskManagerDbContext _dbContext;
    
    private readonly IJwtProvider _jwtProvider;
    
    private readonly IUserRepository _userRepository;
    
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    
    private readonly IUserFromClaims _userFromClaims;
    public UsersService(IHttpContextAccessor httpContextAccessor,IUserRepository userRepository,IJwtProvider jwtProvider,TaskManagerDbContext dbContext,IPasswordHasher passwordHasher, IRefreshTokenRepository refreshTokenRepository, IUserFromClaims userFromClaims)
    {
        _passwordHasher = passwordHasher;
        _refreshTokenRepository = refreshTokenRepository;
        _userFromClaims = userFromClaims;
        _dbContext = dbContext;
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<string> UpdateToken()
    {
        var userId = _userFromClaims.GetUserFromClaimsFromCookie();

        if (userId == null)
        {
            throw new UnauthorizedAccessException("Не авторизован");
        }
            
        var user =  await _userRepository.GetById(userId);

        if (user == null)
        {
            throw new UnauthorizedAccessException("Не авторизован");
        }

        var newToken = _jwtProvider.GenerateToken(user);
        
        return newToken;
    }
    
    public async Task<OutputLoginRequest> Register(string userName, string email, string password)
    {
        var hashedPassword = _passwordHasher.Generate(password);


        var user = new UserEntity
        {
            Id = Guid.NewGuid(),
            UserName = userName,
            Email = email,
            PasswordHash = hashedPassword,
            Tasks = new List<TaskEntity>(),
            RefreshTokens = new List<RefreshTokenEntity>()
        };
        
        try
        {
            await _dbContext.Users.AddAsync(user);

            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new DbUpdateException("Пользователь с данным Email уже существует");
        }
        
        return await Login(email,password,rememberMe: true);
        
    }

    public async Task<OutputLoginRequest> Login(string email, string password, bool rememberMe)
    {
        
        var user = await _userRepository.GetByEmail(email);
        if (user == null)
        {
            throw new UnauthorizedAccessException($"Пользователя с этим email {email} не сушествует");
        }
        
        
        var result = _passwordHasher.Verify(password, user.PasswordHash);

        if (result == false)
        {
            throw new UnauthorizedAccessException("Неправильный пароль");
        }

        if (rememberMe)
        {
            if (!await _refreshTokenRepository.RefreshTokenExists(user.Id))
            {
                var refreshToken = new RefreshTokenEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    IsRevoked = false,
                    RefreshToken = _jwtProvider.GenerateRefreshToken(user)
                };
                
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false,
                    SameSite = SameSiteMode.None,
                    Expires = DateTimeOffset.UtcNow.AddDays(30)
                };
                
                _httpContextAccessor.HttpContext?.Response.Cookies.Append("refreshToken", refreshToken.RefreshToken, cookieOptions);
                
                await _dbContext.RefreshTokens.AddAsync(refreshToken);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                var refreshToken = await _refreshTokenRepository.GetRefreshToken(user.Id);
                
                if (refreshToken == null)
                {
                    throw new UnauthorizedAccessException("Ошибка авторизации");
                }
                
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = false,
                    SameSite = SameSiteMode.None,
                    Expires = DateTimeOffset.UtcNow.AddDays(30)
                };
                
                _httpContextAccessor.HttpContext?.Response.Cookies.Append("refreshToken", refreshToken.RefreshToken, cookieOptions);
                
            }
        }
        else
        {
            var refreshToken = await _refreshTokenRepository.GetRefreshToken(user.Id);

            if (refreshToken == null)
            {
                throw new UnauthorizedAccessException("Ошибка авторизации");
            }
            
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.None,
                Expires = null
            };
            
            _httpContextAccessor.HttpContext?.Response.Cookies.Append("refreshToken", refreshToken.RefreshToken, cookieOptions);
        }
        
        var token = _jwtProvider.GenerateToken(user);
        
        var outputRequest = new OutputLoginRequest(user.Id, user.UserName, user.Email, token);
        
        return outputRequest;
    }
}