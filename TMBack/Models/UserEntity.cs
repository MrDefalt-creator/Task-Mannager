namespace TMBack.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public required string UserName { get; set; }

        public required string Email { get; set; }

        public required string PasswordHash { get; set; }

        public List<TaskEntity> Tasks { get; set; } = [];

        public List<RefreshTokenEntity> RefreshTokens { get; set; } = [];
    }
}
