namespace TMBack.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public required string UserName { get; set; }

        public required string Email { get; set; }

        public required string PasswordHash { get; set; }

        public List<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();

        public List<RefreshTokenEntity> RefreshTokens { get; set; } = new List<RefreshTokenEntity>();
    }
}
