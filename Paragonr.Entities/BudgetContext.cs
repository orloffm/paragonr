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
        
        public DbSet<Spending> Spendings { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public DbSet<Domain> Domains { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
