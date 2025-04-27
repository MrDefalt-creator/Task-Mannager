using System.IdentityModel.Tokens.Jwt;
using TMBack.Interfaces.Auth;

namespace TMBack.Infrastructure
{
    public class UserFromClaims : IUserFromClaims
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UserFromClaims(IHttpContextAccessor httpContextAccessor) {
        
            _httpContextAccessor = httpContextAccessor;

        }
        
        public Guid GetUserFromClaimsFromCookie()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst("userId")?.Value;

            if (!Guid.TryParse(userIdClaim, out var userId))
            {
                throw new Exception("Invalid or missing user ID in JWT.");
            }

            return userId;
        }

        public Guid GetUserFromClaimsFromHeader()
        {
            var claim = _httpContextAccessor.HttpContext?.Request.Headers["JWT"].ToString();
            
            var userIdvValue = new JwtSecurityTokenHandler().ReadJwtToken(claim).Claims.FirstOrDefault(x => x.Value == "userId")?.Value;

            if (!Guid.TryParse(userIdvValue, out var userId))
            {
                throw new Exception("Invalid or missing user ID in JWT.");
            }
            
            return userId;
            
        }
    }
}
