using Domain.DTOs;
using Domain.Repositories;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task<List<BookDto>> GetBooks(string searchKey)
    {
        var books = this._context.Books.AsQueryable();
        return await books.Where(book => book.ContainsSearch(searchKey)).Select(book => new BookDto(book)).ToListAsync();
    }
}
