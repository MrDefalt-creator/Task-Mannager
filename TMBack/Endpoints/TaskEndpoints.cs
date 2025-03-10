using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMBack.Contracts.Task;
using TMBack.Services;

namespace TMBack.Endpoints;
using TMBack.Models;
public static class TaskEndpoints
{
    public static IEndpointRouteBuilder MapTasksEndpoints(this IEndpointRouteBuilder app)
    {
       var endpoints = app.MapGroup("tasks").RequireAuthorization();
       
       endpoints.MapPost(string.Empty, CreateTask);
       
       endpoints.MapGet(string.Empty, GetTasks);

       endpoints.MapGet("{id:guid}", GetTaskById);
       
       endpoints.MapPatch("{id:guid}", UpdateTask);
       
       endpoints.MapDelete("{id:guid}", DeleteTask);
       
       
       return endpoints;
    }

    private static async Task<IResult> GetTasks(TaskService service)
    {
        var tasks = await service.GetTasks();

        return Results.Ok(tasks);
    }

    private static async Task<IResult> GetTaskById([FromRoute]Guid id, TaskService service)
    {
        var task = await service.GetTaskById(id);
        return Results.Ok(task);
    }
    private static async Task<IResult> CreateTask([FromBody] CreateTaskRequest request, TaskService service)
    {
        var task = await service.CreateTask(request.Title, request.Description, request.MustFinishAt);
        return Results.Ok(task);
    }

    private static async Task<IResult> UpdateTask([FromRoute]Guid id, [FromBody]UpdateTaskRequest request, TaskService service)
    {
        await service.UpdateTask(id, request.Title, request.Description, request.MustFinishAt);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteTask([FromRoute]Guid id, TaskService service)
    {
        await service.DeleteTask(id);
        return Results.Ok();
    }


}