using System.Net.Mime;
using Domain.Exceptions;
using Domain.Resources;
using Newtonsoft.Json;

namespace WebApi.Modules.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;

            switch (error)
            {
                case InvalidRequestException invalidRequest:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    await response.WriteAsync(JsonConvert.SerializeObject(new { message = invalidRequest.ErrorMessages }));
                    return;
                case PageOutOfRangeException invalidRequest:
                    response.StatusCode = StatusCodes.Status416RangeNotSatisfiable;
                    await response.WriteAsync(JsonConvert.SerializeObject(new { message = invalidRequest.Message }));
                    return;
                default:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    await response.WriteAsync(JsonConvert.SerializeObject(new { message = Messages.InternalServerError }));
                    return;
            }
        }
    }
}
