using IT.Valor.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Valor.Infrastructure.Data.Configurations
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.Property(q => q.Content)
                .IsRequired();

            builder.HasOne(q => q.AddedBy)
                .WithMany(u => u.Quotes)
                .HasForeignKey(q => q.AddedById)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(q => q.Author)
                .WithMany(a => a.Quotes)
                .HasForeignKey(q => q.AuthorId);

            builder.HasOne(q => q.Book)
                .WithMany(a => a.Quotes)
                .HasForeignKey(q => q.BookId);
        }
    }
}
