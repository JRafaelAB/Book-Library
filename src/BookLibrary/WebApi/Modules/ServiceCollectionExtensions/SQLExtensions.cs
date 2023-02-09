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
        string connectionString = configuration.GetConnectionString(ConnectionStringsConstants.LIBRARY_CONNECTION);
        
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
