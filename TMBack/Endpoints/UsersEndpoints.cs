using TMBack.Contracts.User;
using TMBack.Services;

namespace TMBack.Endpoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);
        
        app.MapPost("login", Login);
        
        return app;
    }

    private static async Task<IResult> Register(RegisterUserRequest request,UsersService usersService)
    {
        await usersService.Register(request.UserName, request.Email, request.Password);
        
        return Results.Ok(usersService);
    }

    private static async Task<IResult> Login(LoginUserRequest request,UsersService usersService)
    {
        var token = await usersService.Login(request.Email, request.Password);

        return Results.Ok(token);
    }
}