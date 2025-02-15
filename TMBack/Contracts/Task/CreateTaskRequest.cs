using System.ComponentModel.DataAnnotations;

namespace TMBack.Contracts.Task;

public record CreateTaskRequest(
    [Required] string Title,
    string? Description,
    [Required] DateOnly MustFinishAt
    );