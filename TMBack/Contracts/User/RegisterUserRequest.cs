using System.Diagnostics.Contracts;

namespace TMBack.Contracts.User;

public class RegisterUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    [ContractInvariantMethod]
    private void ObjectInvariant()
    {
        Contract.Invariant(!string.IsNullOrEmpty(Username), "Имя пользователя не должно быть пустым.");
        Contract.Invariant(!string.IsNullOrEmpty(Password), "Пароль не может быть пустым.");
        Contract.Invariant(!string.IsNullOrEmpty(Email), "Электронная почта не может быть пустой.");
        Contract.Invariant(Email.Contains("@"), "Электронная почта должна содержать символ '@'.");
    }   
}