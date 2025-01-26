
using System.ComponentModel.DataAnnotations;

public record RegisterUserRequest(
    [Required] string UserName,
    [Required] string Email,
    [Required] string Password
    );