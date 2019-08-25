using Paragonr.Application.Dtos;

namespace Paragonr.Application.Queries.Info
{
    public sealed class InfoResult
    {
        public InfoResult(CurrencyDto[] currencies, CurrentRatesInfoDto ratesInfo, DomainDto[] domains, CategoryDto[] categories)
        {
            Currencies = currencies;
            RatesInfo = ratesInfo;
            Domains = domains;
            Categories = categories;
        }

        public CategoryDto[] Categories { get; }

        public CurrencyDto[] Currencies { get; }

        public DomainDto[] Domains { get; }

        public CurrentRatesInfoDto RatesInfo { get; }
    }
}