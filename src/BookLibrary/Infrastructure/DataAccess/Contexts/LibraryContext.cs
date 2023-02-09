using Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Contexts;

public class LibraryContext : DbContext
{
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
