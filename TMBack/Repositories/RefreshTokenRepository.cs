using TMBack.Interfaces.Repositories;

namespace TMBack.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    
    private readonly TaskManagerDbContext _dbContext;

    public RefreshTokenRepository(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public bool RefreshTokenExists(Guid userId)
    {
        return _dbContext.RefreshTokens.Any(x => x.UserId == userId && x.IsRevoked == false);
    }
}