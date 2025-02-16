using Microsoft.AspNetCore.Mvc;
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

    private static async Task<IResult> Register([FromBody]RegisterUserRequest request,UsersService usersService)
    {
        await usersService.Register(request.UserName, request.Email, request.Password);
        
        return Results.Ok();
    }

    private static async Task<IResult> Login([FromBody]LoginUserRequest request, UsersService usersService, HttpContext context)
    {
        var token = await usersService.Login(request.Email, request.Password, request.RememberMe);
        
        /* Название JWT является не безопасным и используются для теста!!! */
        
        
        return Results.Ok();
    }
}