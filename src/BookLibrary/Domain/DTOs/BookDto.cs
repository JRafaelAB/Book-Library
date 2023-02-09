using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Domain.DTOs;

public class BookDto
{
    public long Id { get; init; }
    [MaxLength(100)]
    public string Title { get; }
    [MaxLength(50)]
    public string FirstName { get; }
    [MaxLength(50)]
    public string LastName { get; }
    public int TotalCopies { get; }
    public int CopiesInUse { get; }
    [MaxLength(50)]
    public string Type { get; }
    [MaxLength(80)]
    public string ISBN { get; }
    [MaxLength(50)]
    public string Category { get; }

    public BookDto(string title, string firstName, string lastName, int totalCopies, int copiesInUse, string type, string isbn, string category)
    {
        Title = title;
        FirstName = firstName;
        LastName = lastName;
        TotalCopies = totalCopies;
        CopiesInUse = copiesInUse;
        Type = type;
        ISBN = isbn;
        Category = category;
    }

    public BookDto(Book book)
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
}
