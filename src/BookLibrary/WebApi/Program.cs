using WebApi.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjections();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();