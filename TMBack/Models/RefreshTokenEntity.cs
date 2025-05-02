namespace TMBack.Models
{
    public class RefreshTokenEntity
    {
        public Guid Id { get; set; }

        public required string RefreshToken { get; set; }
        
        public bool IsRevoked { get; set; }

        public Guid UserId { get; set; }

        public UserEntity User { get; set; }
    }
}
