using TMBack.Models;
using Microsoft.EntityFrameworkCore;
namespace TMBack.Repositories;

public class UserRepository
{
    private readonly TaskManagerDbContext _dbContext;

    public UserRepository(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserEntity> GetByEmail(string email)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}