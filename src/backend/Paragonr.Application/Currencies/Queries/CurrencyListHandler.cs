using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paragonr.Application.Interfaces;
using Paragonr.Application.Queries.List;
using Paragonr.Entities;

namespace Paragonr.Application.Currencies.Queries
{
    public sealed class CurrencyListHandler : ListQueryHandler<Currency, CurrencyDto>
    {
        public CurrencyListHandler(IBudgetDbContext context, IMapper mapper) : base(mapper)
        {
            EntityDbSet = context.Currencies;
        }

        protected override DbSet<Currency> EntityDbSet { get; }
    }
}