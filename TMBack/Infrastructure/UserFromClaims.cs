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
            var refreshToken = _httpContextAccessor.HttpContext?.Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(refreshToken))
            {
                throw new Exception("Refresh token cookie not found.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(refreshToken);

            var userIdClaim = token.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            {
                throw new Exception("Invalid or missing user ID in JWT.");
            }

            return userId;
        }

        public Guid GetUserFromClaimsFromHeader()
        {
            var claim = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            
            var userIdvValue = new JwtSecurityTokenHandler().ReadJwtToken(claim).Claims.FirstOrDefault(x => x.Value == "userId")?.Value;

            if (!Guid.TryParse(userIdvValue, out var userId))
            {
                throw new Exception("Invalid or missing user ID in JWT.");
            }
            
            return userId;
            
        }
    }
}
