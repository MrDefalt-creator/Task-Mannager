using TMBack.Interfaces.Auth;

namespace TMBack.Services;

public class UsersService
{
    private readonly IPasswordHasher _passwordHasher;
    
    public UsersService(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }
    
    public async Task Register(string userName, string email, string password)
    {
        var hashedPassword = _passwordHasher.Generate(password);
    }
}