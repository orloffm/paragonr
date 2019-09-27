using Paragonr.Application.Dtos;

namespace Paragonr.Application.Queries.Info
{
    public sealed class InfoResult
    {
        public InfoResult(CurrencyDto[] currencies, CurrentRatesInfoDto ratesInfo, FieldDto[] fields, CategoryDto[] categories)
        {
            Currencies = currencies;
            RatesInfo = ratesInfo;
            Fields = fields;
            Categories = categories;
        }

        public CategoryDto[] Categories { get; }

        public CurrencyDto[] Currencies { get; }

        public FieldDto[] Fields { get; }

        public CurrentRatesInfoDto RatesInfo { get; }
    }
}
