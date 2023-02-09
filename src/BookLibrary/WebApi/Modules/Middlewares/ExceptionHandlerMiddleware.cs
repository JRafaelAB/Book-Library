using System.Net.Mime;
using Domain.Exceptions;
using Domain.Resources;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace WebApi.Modules.Middlewares;

internal static class ExceptionHandlerMiddleware
{
    public static async Task ExceptionHandler(HttpContext context, ILogger logger)
    {
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        context.Response.ContentType = MediaTypeNames.Application.Json;
        if (contextFeature != null)
        {
            switch (contextFeature.Error)
            {
                case InvalidRequestException invalidRequest:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    logger.LogError($"Invalid Request: {JsonConvert.SerializeObject(invalidRequest)}");
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(invalidRequest));
                    break;

                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    logger.LogError($"Unexpected Error: {contextFeature.Error}");
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(Messages.InternalServerError));
                    break;
            }
        }
    }
}
