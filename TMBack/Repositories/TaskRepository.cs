using Microsoft.EntityFrameworkCore;
using TMBack.Interfaces.Repositories;
using TMBack.Models;

namespace TMBack.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerDbContext _dbContext;

        public TaskRepository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskEntity> GetTaskById(Guid taskId, Guid userId)
        {
            return await _dbContext.Tasks
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == taskId && t.UserId == userId);
        }

        public async Task<List<TaskEntity>> GetTasks(Guid userId)
        {
            return await _dbContext.Tasks
                .AsNoTracking()
                .Where(t => t.UserId == userId) 
                .ToListAsync();
        }
    }
}
