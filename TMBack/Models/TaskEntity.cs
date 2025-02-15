using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TMBack.Models
{
    public class TaskEntity
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateOnly MustFinish { get; set; }

        public Guid UserId { get; set; }

        public required UserEntity User { get; set; }
    }
}
