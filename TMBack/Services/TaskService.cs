using Microsoft.Extensions.Configuration.UserSecrets;
using TMBack.Interfaces.Auth;
using TMBack.Interfaces.Repositories;
using TMBack.Models;

namespace TMBack.Services;

public class TaskService
{
    private readonly TaskManagerDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IUserFromClaims _userFromClaims;
    public TaskService(IUserFromClaims userFromClaims,TaskManagerDbContext dbContext, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, ITaskRepository taskRepository)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
        _taskRepository = taskRepository;
        _userFromClaims = userFromClaims;

    }

    public async Task<Guid> CreateTask(string title, string? description, DateOnly mustFinishDate)
    {
        Guid userId = _userFromClaims.GetUserFromClaimsFromHeader();
        
        var user = await _userRepository.GetById(userId);
        var task = new TaskEntity
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            CreatedAt = DateTime.UtcNow,
            MustFinish = mustFinishDate,
            UserId = userId,
            User = user
        };

            _dbContext.Users.Attach(user);
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();

            return task.Id;

    }

    public async Task<List<TaskEntity>> GetTasks()
    {
        Guid userId = _userFromClaims.GetUserFromClaimsFromHeader();

        var tasks = await _taskRepository.GetTasks(userId);
        if (tasks == null)
        {
            throw new KeyNotFoundException("У вас нет задач");
        }

        return tasks;
        
    }

    public async Task<TaskEntity> GetTaskById(Guid taskId)
    {
        Guid userId = _userFromClaims.GetUserFromClaimsFromHeader();

        var task = await _taskRepository.GetTaskById(taskId, userId);
        if (task == null)
        {
            throw new KeyNotFoundException("Такой задачи не существует");
        }

        return task;
    }

    public async Task UpdateTask(Guid taskId, string? newTitle, string? newDescription, DateOnly? newMustFinishDate)
    {
        Guid userId = _userFromClaims.GetUserFromClaimsFromHeader();

        var task = await _taskRepository.GetTaskById(taskId, userId);

        if (task == null)
        {
            throw new KeyNotFoundException("Задача не найдена или у вас нет прав на её изменение");
        }

        
        if (!string.IsNullOrEmpty(newTitle))
            task.Title = newTitle;

        if (!string.IsNullOrEmpty(newDescription))
            task.Description = newDescription;

        if (newMustFinishDate.HasValue)
            task.MustFinish = newMustFinishDate.Value;

        
        _dbContext.Tasks.Update(task);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteTask(Guid taskId)
    {
        Guid userId = _userFromClaims.GetUserFromClaimsFromHeader();
        
        var task = await _taskRepository.GetTaskById(taskId, userId);
        if (task == null)
        {
            throw new KeyNotFoundException("Задача не найдена или у вас нет прав на её изменение");
        }
        
        _dbContext.Tasks.Remove(task);
        await _dbContext.SaveChangesAsync();
        
    }

}