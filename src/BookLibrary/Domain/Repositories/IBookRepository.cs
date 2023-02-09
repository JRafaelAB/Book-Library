using Domain.DTOs;

namespace Domain.Repositories;

public interface IBookRepository
{
    Task<List<BookDto>> GetBooks(string searchKey);
}
