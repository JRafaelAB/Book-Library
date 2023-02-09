using Domain.Constants;
using Domain.UnitOfWork;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Modules.ServiceCollectionExtensions;

internal static class SQLExtensions
{
    public static IServiceCollection AddSQLServer(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetValue<string>(ConfigurationConstants.SQL_CLOCK_CONNECTION_STRING) ?? string.Empty;
        
        services.AddDbContext<LibraryContext>(
            options =>
            {
                options.UseSqlServer(connectionString, option => option.MigrationsAssembly(nameof(Infrastructure)));
                options.EnableSensitiveDataLogging();
            });
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
