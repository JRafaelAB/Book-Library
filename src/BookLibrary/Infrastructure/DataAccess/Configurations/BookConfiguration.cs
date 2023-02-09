using Domain.Entities;
using Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations;

public sealed class BookConfiguration
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ValidateNullArgument(nameof(builder));

        builder.ToTable(nameof(Book));
            
        builder.HasKey(book => book.Id);
        builder.Property(book => book.Title).HasMaxLength(100).IsRequired();
        builder.Property(book => book.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(book => book.LastName).HasMaxLength(50).IsRequired();
        builder.Property(book => book.TotalCopies).IsRequired().HasDefaultValue(0);
        builder.Property(book => book.CopiesInUse).IsRequired().HasDefaultValue(0);
        builder.Property(book => book.Type).HasMaxLength(50);
        builder.Property(book => book.ISBN).HasMaxLength(80);
        builder.Property(book => book.Category).HasMaxLength(50);
    }
    
}
