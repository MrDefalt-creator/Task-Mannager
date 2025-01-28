using TMBack.Models;

namespace TMBack.Interfaces.Auth;

public interface IJwtProvider
{
    string GenerateToken(UserEntity user);
    
    string GenerateRefreshToken(UserEntity user);
}