using System.ComponentModel.DataAnnotations;

namespace TMBack.Contracts.User;

public record OutputLoginRequest(
    [Required] Guid UserId,
    [Required] string Username,
    [Required] string Email    
    )
{
}