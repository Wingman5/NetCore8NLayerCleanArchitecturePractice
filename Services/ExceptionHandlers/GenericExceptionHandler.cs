using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace App.Services.ExceptionHandlers;

public class GenericExceptionHandler : IExceptionHandler
{
    public void Handle(Exception exception)
    {
        // Log the generic exception details
        Console.WriteLine($"Generic Exception: {exception.Message}");
        // Additional logic for handling generic exceptions can be added here
    }
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var errorAsDto = ServiceResult.Failure(exception.Message, HttpStatusCode.InternalServerError);

        httpContext.Response.StatusCode = (int)errorAsDto.Status;
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.WriteAsJsonAsync(errorAsDto, cancellationToken);

        return ValueTask.FromResult(true);
    }
}

