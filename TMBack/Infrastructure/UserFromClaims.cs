using TMBack.Interfaces.Auth;

namespace TMBack.Infrastructure
{
    public class UserFromClaims : IUserFromClaims
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UserFromClaims(IHttpContextAccessor httpContextAccessor) {
        
            _httpContextAccessor = httpContextAccessor;

        }
        
        public Guid GetUserFromClaims()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst("userId")?.Value;

            if (!Guid.TryParse(userIdClaim, out var userId))
            {
                throw new Exception("Invalid or missing user ID in JWT.");
            }

            return userId;
        }
    }
}
