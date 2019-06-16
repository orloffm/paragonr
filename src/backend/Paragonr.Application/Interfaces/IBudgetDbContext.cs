using Microsoft.EntityFrameworkCore;
using Paragonr.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Paragonr.Application
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
