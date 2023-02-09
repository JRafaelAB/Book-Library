using System.ComponentModel.DataAnnotations;
using Domain.DTOs;

namespace Domain.Entities;

public class Book
{
    public long Id { get; init; }
    [MaxLength(100)]
    public string Title { get; init; }
    [MaxLength(50)]
    public string FirstName { get; init; }
    [MaxLength(50)]
    public string LastName { get; init; }
    public int TotalCopies { get; init; }
    public int CopiesInUse { get; init; }
    [MaxLength(50)]
    public string Type { get; init; }
    [MaxLength(80)]
    public string ISBN { get; init; }
    [MaxLength(50)]
    public string Category { get; init; }

    private Book()
    {
        
    }
    
    public Book(string Title, string FirstName, string LastName, int TotalCopies, int CopiesInUse, string Type, string ISBN, string Category)
    {
        this.Title = Title;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.TotalCopies = TotalCopies;
        this.CopiesInUse = CopiesInUse;
        this.Type = Type;
        this.ISBN = ISBN;
        this.Category = Category;
    }

    public Book(BookDto book)
    {
        Id = book.Id;
        Title = book.Title;
        FirstName = book.FirstName;
        LastName = book.LastName;
        TotalCopies = book.TotalCopies;
        CopiesInUse = book.CopiesInUse;
        Type = book.Type;
        ISBN = book.ISBN;
        Category = book.Category;
    }

    public bool ContainsSearch(string searchKey)
    {
        return Title.Contains(searchKey)
               || FirstName.Contains(searchKey)
               || LastName.Contains(searchKey)
               || Category.Contains(searchKey)
               || ISBN.Contains(searchKey);
    }
}
