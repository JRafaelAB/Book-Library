using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebApi.Modules;
using WebApi.Modules.Middlewares;
using WebApi.Modules.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjections(builder.Configuration);

var app = builder.Build();

app.ConfigureSwagger(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.UseExceptionHandler(appError =>
{
    appError.Run(async context => 
        await ExceptionHandlerMiddleware.ExceptionHandler
            (context, app.Services.GetRequiredService<ILogger>()));
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();