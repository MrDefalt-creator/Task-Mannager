using Microsoft.EntityFrameworkCore;
using TMBack.Models;

namespace TMBack
{
    
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserEntity> User { get; set; }
        
        public DbSet<TaskEntity> Task { get; set; }
        
        public DbSet<RefreshTokenEntity> RefreshToken { get; set; }
    }
}
