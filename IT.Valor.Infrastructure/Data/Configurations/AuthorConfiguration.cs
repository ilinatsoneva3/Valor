using IT.Valor.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Valor.Infrastructure.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a => a.FirstName)
                .HasMaxLength(64);

            builder.Property(a => a.LastName)
                .HasMaxLength(64);

            builder.Property(a => a.Pseudonym)
               .HasMaxLength(64);

            builder.HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            builder.HasMany(a => a.Quotes)
               .WithOne(q => q.Author)
               .HasForeignKey(q => q.AuthorId);
        }
    }
}
