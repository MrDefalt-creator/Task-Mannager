
using System.ComponentModel.DataAnnotations;

namespace TMBack.Contracts.User;

public record RegisterUserRequest(
    [Required] string UserName,
    [Required] string Email,
    [Required] string Password
);