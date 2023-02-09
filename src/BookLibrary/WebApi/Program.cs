using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebApi.Modules;
using WebApi.Modules.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjections();

var app = builder.Build();

app.ConfigureSwagger(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();