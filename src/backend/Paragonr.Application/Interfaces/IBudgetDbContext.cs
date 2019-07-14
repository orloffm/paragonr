using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paragonr.Entities;

namespace Paragonr.Application.Interfaces
{
    public interface IBudgetDbContext
    {
        DbSet<Category> Categories { get; set; }

        DbSet<Currency> Currencies { get; set; }

        DbSet<CurrencyRate> CurrencyRates { get; set; }

        DbSet<Domain> Domains { get; set; }

        DbSet<Spending> Spendings { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}