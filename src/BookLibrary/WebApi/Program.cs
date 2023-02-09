using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebApi.Modules;
using WebApi.Modules.Middlewares;
using WebApi.Modules.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjections(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.ConfigureSwagger(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());

app.MapControllers();

app.Run();