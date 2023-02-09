using Domain.DTOs;

namespace Application.UseCases.SearchBooks;

public class SearchBooksUseCase : ISearchBooksUseCase
{
    public async Task<PaginationDto<BookDto>> Execute(string searchKey)
    {
        await Task.WhenAny();

        return new PaginationDto<BookDto>(new List<BookDto>(), 1);
    } 
}
