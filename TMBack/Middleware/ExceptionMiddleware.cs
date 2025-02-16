using System.Net;
using System.Text.Json;

namespace TMBack.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        var statusCode = exception switch
        {
            ArgumentException => (int)HttpStatusCode.BadRequest,  // Ошибка клиента (400)
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized, // Ошибка авторизации (401)
            KeyNotFoundException => (int)HttpStatusCode.NotFound, // Ресурс не найден (404)
            _ => (int)HttpStatusCode.InternalServerError
        };
        
        response.StatusCode = statusCode;

        var errorResponse = new
        {
            statusCode = response.StatusCode,
            message = exception.Message,
            details = exception.StackTrace
        };
        
        var json = JsonSerializer.Serialize(errorResponse);
        return context.Response.WriteAsync(json);
    }
}

