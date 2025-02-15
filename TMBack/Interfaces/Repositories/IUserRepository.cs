using TMBack.Models;

namespace TMBack.Interfaces.Repositories;

public interface IUserRepository
{
    Task<UserEntity> GetByEmail(string email);
    
    Task<UserEntity> GetById(Guid id);
}