using Domain.DTOs;
using Domain.Repositories;

namespace Application.UseCases.GetAllBooks;

public class GetAllBooksUseCase : IGetAllBooksUseCase
{
    private readonly IBookRepository _bookRepository;

    public GetAllBooksUseCase(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<PaginationDto<BookDto>> Execute(int page)
    {
        var books = await _bookRepository.GetAllBooks();
        return new PaginationDto<BookDto>(books, page);
    } 
    
}
