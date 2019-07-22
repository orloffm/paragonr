using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Paragonr.Application.Dtos;
using Paragonr.Business.Interfaces;
using Paragonr.Business.Models;
using Paragonr.Entities;

namespace Paragonr.Application.Queries.Info
{
    // ReSharper disable once UnusedMember.Global
    public sealed class InfoQueryHandler : IRequestHandler<InfoQuery, InfoResult>
    {
        private const string DefaultCurrencyIsoCode = "PLN";
        private readonly IBudgetDbContext _context;
        private readonly IRateProvider _rates;
        private readonly IMapper _mapper;

        public InfoQueryHandler(IBudgetDbContext context, IRateProvider rates, IMapper mapper)
        {
            _context = context;
            _rates = rates;
            _mapper = mapper;
        }

        public async Task<InfoResult> Handle(InfoQuery request, CancellationToken cancellationToken)
        {
            CurrencyDto[] currencies = await ProjectAsync<Currency, CurrencyDto>(_context.Currencies, cancellationToken);

            CurrentRatesInfoDto ratesInfo = LoadRates(currencies);

            DomainDto[] domains = await ProjectAsync<Domain, DomainDto>(_context.Domains, cancellationToken);

            CategoryDto[] categories = await ProjectAsync<Category, CategoryDto>(_context.Categories, cancellationToken);

            return new InfoResult(currencies, ratesInfo, domains, categories);
        }

        private async Task<TDto[]> ProjectAsync<TEntity, TDto>(DbSet<TEntity> source, CancellationToken token)
        where TEntity : EntityBase
        {
            return await source.ProjectTo<TDto>(_mapper.ConfigurationProvider)
                .ToArrayAsync(token);
        }

        private CurrentRatesInfoDto LoadRates(CurrencyDto[] currencies)
        {
            var rates = new List<CurrencyRateInfoDto>();

            foreach (CurrencyDto currency in currencies)
            {
                if (currency.IsoCode == DefaultCurrencyIsoCode)
                {
                    continue;
                }

                RateInfo rate = _rates.GetRateOrDefault(currency.IsoCode, DefaultCurrencyIsoCode);
                if (rate == null)
                {
                    continue;
                }

                var currencyRateInfo = new CurrencyRateInfoDto(currency.IsoCode, rate.Rate, rate.Date);
                rates.Add(currencyRateInfo);
            }

            var ratesInfo = new CurrentRatesInfoDto(rates, DefaultCurrencyIsoCode);

            return ratesInfo;
        }
    }
}