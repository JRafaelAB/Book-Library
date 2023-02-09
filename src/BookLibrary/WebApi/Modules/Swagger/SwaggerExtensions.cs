using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace WebApi.Modules.Swagger;

internal static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Book Library",
                Description = "Book library database back-end.",
                Contact = new OpenApiContact
                {
                    Name = "Jonas Borges",
                    Email = "[jonasrafael97@hotmail.com]"
                }
            });
        });
        services.AddSwaggerGenNewtonsoftSupport();
        return services;
    }

    public static void ConfigureSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
                options.RoutePrefix = string.Empty;
            }
        });
    }
}
