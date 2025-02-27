﻿using System.Diagnostics;
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
    public UsersService(IHttpContextAccessor httpContextAccessor,IUserRepository userRepository,IJwtProvider jwtProvider,TaskManagerDbContext dbContext,IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
        _dbContext = dbContext;
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
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
        
        await _dbContext.Users.AddAsync(user);
        
        await _dbContext.SaveChangesAsync();
        
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
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Secure = false,
            SameSite = SameSiteMode.None,
            Expires = rememberMe ? DateTime.UtcNow.AddDays(30) : null 
        };

        var outputRequest = new OutputLoginRequest(user.Id, user.UserName, user.Email);

        var token = _jwtProvider.GenerateToken(user);
        _httpContextAccessor.HttpContext?.Response.Cookies.Append("JWT",token,cookieOptions);
        return outputRequest;
    }
}