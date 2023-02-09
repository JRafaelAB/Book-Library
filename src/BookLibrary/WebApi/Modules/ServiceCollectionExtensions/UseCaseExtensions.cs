using Application.UseCases.GetAllBooks;
using Application.UseCases.SearchBooks;

namespace WebApi.Modules.ServiceCollectionExtensions;

public static class UseCaseExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ISearchBooksUseCase, SearchBooksUseCase>();
        services.AddScoped<IGetAllBooksUseCase, GetAllBooksUseCase>();

        return services;
    }
    
}
