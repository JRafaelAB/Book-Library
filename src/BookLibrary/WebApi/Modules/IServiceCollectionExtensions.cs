using WebApi.Modules.ServiceCollectionExtensions;

namespace WebApi.Modules;

internal static class IServiceCollectionExtensions
{
    public static void AddDependencyInjections(this IServiceCollection services)
    {
        services
            .AddVersioning()
            .AddControllers();
    }
}
