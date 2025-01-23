public class RegisterUserRequest
{
    private string _username;
    private string _password;
    private string _email;

    public string Username
    {
        get => _username;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Имя пользователя не должно быть пустым.");
            _username = value;
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Пароль не может быть пустым.");
            _password = value;
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Электронная почта не может быть пустой.");
            if (!value.Contains("@"))
                throw new ArgumentException("Электронная почта должна содержать символ '@'.");
            _email = value;
        }
    }
}