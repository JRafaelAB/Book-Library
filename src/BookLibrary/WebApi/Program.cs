using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebApi.Modules;
using WebApi.Modules.Middlewares;
using WebApi.Modules.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjections(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.ConfigureSwagger(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();