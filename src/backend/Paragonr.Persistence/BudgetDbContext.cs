using Microsoft.EntityFrameworkCore;
using Paragonr.Application;
using Paragonr.Entities;

namespace Paragonr.Persistence
{
    public class BudgetDbContext : DbContext, IBudgetDbContext
    {
        public BudgetDbContext()
        {

        }

        public BudgetDbContext(DbContextOptions<BudgetDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BudgetDbContext).Assembly);
        }

        public DbSet<Spending> Spendings { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public DbSet<Domain> Domains { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
