using TMBack.Interfaces.Auth;
using TMBack.Models;

namespace TMBack.Services;

public class UsersService
{
    private readonly IPasswordHasher _passwordHasher;

    private readonly TaskManagerDbContext _dbContext;
    
    public UsersService(TaskManagerDbContext dbContext,IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
        _dbContext = dbContext;
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
        return "";
    }
}