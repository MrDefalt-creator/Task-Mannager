using TMBack.Models;

namespace TMBack.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskEntity>> GetTasks(Guid userId);

        Task<TaskEntity> GetTaskById(Guid taskId, Guid userId);
    }
}
