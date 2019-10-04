using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paragonr.Domain.Entities;

namespace Paragonr.Domain
{
    public interface IBudgetDbContext
    {
        DbSet<Category> Categories { get; set; }

        DbSet<Currency> Currencies { get; set; }

        DbSet<CurrencyRate> CurrencyRates { get; set; }

        DbSet<Field> Fields { get; set; }

        DbSet<Spending> Spendings { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<Budget> Budgets { get; set; }

        DbSet<Membership> Memberships { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
    }
}
