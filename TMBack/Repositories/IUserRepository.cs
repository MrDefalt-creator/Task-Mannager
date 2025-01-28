using TMBack.Models;
using Microsoft.EntityFrameworkCore;
namespace TMBack.Repositories;

public class IUserRepository
{
    private readonly TaskManagerDbContext _dbContext;

    public IUserRepository(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserEntity> GetByEmail(string email)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception("User not found");
    }
}