using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paragonr.Entities;

namespace Paragonr.Application.Interfaces
{
    public interface IBudgetDbContext
    {
        DbSet<Spending> Spendings { get; set; }

        DbSet<Currency> Currencies { get; set; }

        DbSet<CurrencyRate> CurrencyRates { get; set; }

        DbSet<Domain> Domains { get; set; }

        DbSet<Category> Categories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
