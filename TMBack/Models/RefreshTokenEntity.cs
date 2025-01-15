namespace TMBack.Models
{
    public class RefreshTokenEntity
    {
        public Guid Id { get; set; }

        public required string RefreshToken { get; set; }

        public Guid UserId { get; set; }

        public required UserEntity User { get; set; }
    }
}
