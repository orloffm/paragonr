using System;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Paragonr.Entities
{


    public sealed class BudgetContext : DbContext
    {
        public BudgetContext()
        {
            
        }

        public BudgetContext(DbContextOptions<BudgetContext> options)
        : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Make currencies non-main by default.
            modelBuilder.Entity<Currency>().Property(c => c.IsMain).HasDefaultValue(false);
        }

        public DbSet<Spending> Spendings { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public DbSet<Domain> Domains { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
