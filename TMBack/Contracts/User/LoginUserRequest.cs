using System.ComponentModel.DataAnnotations;

namespace TMBack.Contracts.User;

public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password,
    [Required] bool RememberMe
    );