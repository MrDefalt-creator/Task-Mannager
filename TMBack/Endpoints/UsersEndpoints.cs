using TMBack.Services;

namespace TMBack.Endpoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("register", Register);
        
        return app;
    }

    private static async Task<IResult> Register(RegisterUserRequest request,UsersService usersService)
    {
        await usersService.Register(request.Username, request.Email, request.Password);
        
        return Results.Ok(usersService);
    }
}