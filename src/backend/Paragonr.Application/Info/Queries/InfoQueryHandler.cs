using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Paragonr.Application.Currencies;
using Paragonr.Application.Interfaces;
using Paragonr.Application.Models;
using Paragonr.Domain;
using Paragonr.Domain.Entities;
using Paragonr.Tools.Mapping.Extensions;

namespace Paragonr.Application.Info.Queries
{
    // ReSharper disable once UnusedMember.Global
    public sealed class InfoQueryHandler : IRequestHandler<InfoQuery, InfoResult>
    {
        private const string DefaultCurrencyIsoCode = "PLN";
        private readonly IBudgetDbContext _context;
        private readonly IMapper _mapper;
        private readonly IRateProvider _rates;

        public InfoQueryHandler(IBudgetDbContext context, IRateProvider rates, IMapper mapper)
        {
            _context = context;
            _rates = rates;
            _mapper = mapper;
        }

        public async Task<InfoResult> Handle(InfoQuery request, CancellationToken cancellationToken)
        {
            CurrencyDto[] currencies =
                await _context.Currencies.ProjectAsync<Currency, CurrencyDto>(_mapper.ConfigurationProvider, cancellationToken);

            CurrentRatesInfoDto ratesInfo = LoadRates(currencies);

            return new InfoResult(currencies, ratesInfo);
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
