using IT.Valor.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Valor.Infrastructure.Data.Configurations
{
    class UserLikedQuoteConfiguration : IEntityTypeConfiguration<UserLikedQuote>
    {
        public void Configure(EntityTypeBuilder<UserLikedQuote> builder)
        {
            builder.HasKey(ulq => new { ulq.QuoteId, ulq.UserId });

            builder.HasOne(ulq => ulq.User)
                .WithMany(u => u.LikedQuotes)
                .HasForeignKey(ulq => ulq.UserId);

            builder.HasOne(ulq => ulq.Quote)
                .WithMany(q => q.UserLikedQuotes)
                .HasForeignKey(ulq => ulq.QuoteId);
        }
    }
}
