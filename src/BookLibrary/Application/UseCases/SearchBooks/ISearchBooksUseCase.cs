using Domain.DTOs;

namespace Application.UseCases.SearchBooks;

public interface ISearchBooksUseCase
{
    Task<PaginationDto<BookDto>> Execute(string searchKey, int page);
}
