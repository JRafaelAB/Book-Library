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
    public async Task<PaginationDto<BookDto>> Execute(string searchKey, int page)
    {
        var books = await _bookRepository.GetBooks(searchKey);
        var test = new PaginationDto<BookDto>(books, page);
        return test;
    } 
}
