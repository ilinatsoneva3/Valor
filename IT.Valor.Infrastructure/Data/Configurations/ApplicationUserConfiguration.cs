using IT.Valor.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Valor.Infrastructure.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(u => u.Quotes)
                .WithOne(q => q.AddedBy)
                .HasForeignKey(q => q.AddedById);
        }
    }
}
