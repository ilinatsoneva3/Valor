using System;
using IT.Valor.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IT.Valor.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            ConfigureDefaultIdentityTables(builder);
        }

        private void ConfigureDefaultIdentityTables(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<string>>().HasNoKey();
            builder.Entity<IdentityUserToken<string>>().HasNoKey();
            builder.Entity<IdentityUserClaim<string>>().HasKey(x => new { x.Id, x.UserId });
            builder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.RoleId, x.UserId } );

        }
    }
}
