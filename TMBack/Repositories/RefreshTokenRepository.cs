using Microsoft.EntityFrameworkCore;
using TMBack.Interfaces.Repositories;
using TMBack.Models;

namespace TMBack.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    
    private readonly TaskManagerDbContext _dbContext;

    public RefreshTokenRepository(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<bool> RefreshTokenExists(Guid userId)
    {
        return _dbContext.RefreshTokens.Any(x => x.UserId == userId && x.IsRevoked == false);
    }

    public async Task<RefreshTokenEntity?> GetRefreshToken(Guid userId)
    {
        return await _dbContext.RefreshTokens.FirstOrDefaultAsync(x => x.UserId == userId && x.IsRevoked == false);
    }
}