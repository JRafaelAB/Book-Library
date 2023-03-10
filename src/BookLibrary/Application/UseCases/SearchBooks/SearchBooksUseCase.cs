using Domain.DTOs;
using Domain.Repositories;

namespace Application.UseCases.SearchBooks;

public class SearchBooksUseCase : ISearchBooksUseCase
{
    private readonly IBookRepository _bookRepository;

    public SearchBooksUseCase(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<PaginationDto<BookDto>> Execute(string searchKey, int page, int itemsPerPage)
    {
        var books = await _bookRepository.GetBooks(searchKey);
        return new PaginationDto<BookDto>(books, page, itemsPerPage);
    } 
}
