using System.ComponentModel.DataAnnotations;
namespace TMBack.Contracts.Task
{
    public record UpdateTaskRequest(
    
        string? Title,
        string? Description,
        DateOnly? MustFinishAt
        
    ); 
}
