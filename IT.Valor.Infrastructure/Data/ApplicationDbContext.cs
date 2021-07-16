using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IT.Valor.Core.Interfaces.Entities;
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

       public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).DateModified = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
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
