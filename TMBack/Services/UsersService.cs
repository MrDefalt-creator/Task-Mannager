using TMBack.Interfaces.Auth;
using TMBack.Models;
using TMBack.Repositories;

namespace TMBack.Services;

public class UsersService
{
    private readonly IPasswordHasher _passwordHasher;

    private readonly TaskManagerDbContext _dbContext;
    
    private readonly IUserRepository _usersRepository;
    
    private readonly IJwtProvider _jwtProvider;
    public UsersService(IJwtProvider jwtProvider,IUserRepository usersRepository,TaskManagerDbContext dbContext,IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
        _dbContext = dbContext;
        _usersRepository = usersRepository;
        _jwtProvider = jwtProvider;
    }
    
    public async Task Register(string userName, string email, string password)
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
    }

    public async Task<string> Login(string email, string password)
    {
        var user = _usersRepository.GetByEmail(email);

        var result = _passwordHasher.Verify(password, user.Result.PasswordHash);

        if (result == false)
        {
            throw new Exception("Invalid password");
        }

        var token = _jwtProvider.GenerateToken(user.Result);
        
        return "";
    }
}