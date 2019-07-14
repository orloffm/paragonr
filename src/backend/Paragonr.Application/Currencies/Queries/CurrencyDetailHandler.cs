using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paragonr.Application.Interfaces;
using Paragonr.Application.Queries.Detail;
using Paragonr.Entities;

namespace Paragonr.Application.Currencies.Queries
{
    public sealed class CurrencyDetailHandler : DetailQueryHandler<Currency, CurrencyDto>
    {
        public CurrencyDetailHandler(IBudgetDbContext context, IMapper mapper) : base(mapper)
        {
            EntityDbSet = context.Currencies;
        }

        protected override DbSet<Currency> EntityDbSet { get; }
    }
}