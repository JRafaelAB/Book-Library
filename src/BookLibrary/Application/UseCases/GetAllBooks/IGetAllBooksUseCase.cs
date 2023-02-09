using Domain.DTOs;

namespace Application.UseCases.GetAllBooks;

public interface IGetAllBooksUseCase
{
    Task<PaginationDto<BookDto>> Execute(int page);
}
