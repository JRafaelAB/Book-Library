using Domain.Entities;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Contexts;

public class LibraryContext : DbContext
{
    
    public virtual  DbSet<Book> Books { get; set; }
    
    public LibraryContext()
    {
            
    }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ValidateNullArgument(nameof(modelBuilder));

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryContext).Assembly);
    }
}
