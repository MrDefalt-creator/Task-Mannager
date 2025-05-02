namespace TMBack.Interfaces.Auth
{
    public interface IUserFromClaims
    {
         Guid GetUserFromClaimsFromCookie();
         
         Guid GetUserFromClaimsFromHeader();
    }
}
