namespace TMBack.Interfaces.Repositories;

public interface IRefreshTokenRepository
{
    public bool RefreshTokenExists(Guid userId);
}