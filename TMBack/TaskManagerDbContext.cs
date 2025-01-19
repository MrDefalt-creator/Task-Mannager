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
        public DbSet<UserEntity> Users { get; set; }
        
        public DbSet<TaskEntity> Tasks { get; set; }
        
        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }
    }
}
