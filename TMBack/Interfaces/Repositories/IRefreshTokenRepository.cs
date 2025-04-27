using TMBack.Models;

namespace TMBack.Interfaces.Repositories;

public interface IRefreshTokenRepository
{
    public Task<bool> RefreshTokenExists(Guid userId);
    
    public Task<RefreshTokenEntity?> GetRefreshToken(Guid userId);
}