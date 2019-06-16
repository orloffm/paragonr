using Microsoft.EntityFrameworkCore;
using Paragonr.Entities;

namespace Paragonr.Persistence
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BudgetContext).Assembly);
        }

        public DbSet<Spending> Spendings { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public DbSet<Domain> Domains { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
