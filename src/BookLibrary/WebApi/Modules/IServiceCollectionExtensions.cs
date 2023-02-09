using WebApi.Modules.ServiceCollectionExtensions;
using WebApi.Modules.Swagger;

namespace WebApi.Modules;

internal static class IServiceCollectionExtensions
{
    public static void AddDependencyInjections(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSwagger()
            .AddVersioning()
            .AddSQLServer(configuration)
            .AddControllers();
    }
}
