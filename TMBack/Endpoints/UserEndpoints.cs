using Microsoft.AspNetCore.Http.HttpResults;
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

        app.MapPost("update_jwt", UpdateJwt);
        
        return app;
    }

    private static async Task<IResult> Register([FromBody]RegisterUserRequest request,UsersService usersService)
    {
        var outRegisterRequest = await usersService.Register(request.UserName, request.Email, request.Password);
        
        return Results.Ok(outRegisterRequest);
    }

    private static async Task<IResult> Login([FromBody]LoginUserRequest request, UsersService usersService)
    {
        var outputLoginRequest = await usersService.Login(request.Email, request.Password, request.RememberMe);
        
        return Results.Ok(outputLoginRequest);
    }

    private static async Task<IResult> UpdateJwt(UsersService service)
    {
        var newToken = await service.UpdateToken();
        
        return Results.Ok(new {accessToken = newToken});
    }
    
    
}