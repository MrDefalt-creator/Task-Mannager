using Microsoft.EntityFrameworkCore;
using TMBack.Models;

namespace TMBack
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        
        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
