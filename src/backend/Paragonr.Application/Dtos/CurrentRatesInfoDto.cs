using System.Collections.Generic;

namespace Paragonr.Application.Queries.Info
{
    public class CurrentRatesInfoDto
    {
        public CurrentRatesInfoDto(List<CurrencyRateInfoDto> rates, string defaultCurrencyIsoCode)
        {
            Rates = rates.ToArray();
            DefaultCurrency = defaultCurrencyIsoCode;
        }

        public string DefaultCurrency { get; }

        public CurrencyRateInfoDto[] Rates { get; }
    }
}