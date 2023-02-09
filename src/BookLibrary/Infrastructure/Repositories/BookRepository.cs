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
        var books = await this._context.Books.ToListAsync();
        return books.Where(book => book.ContainsSearch(searchKey)).Select(book => new BookDto(book)).ToList();
    }
    
    public async Task<List<BookDto>> GetAllBooks()
    {
       return await this._context.Books.Select(book => new BookDto(book)).ToListAsync();
    }
}
