using Paragonr.Application.Currencies;

namespace Paragonr.Application.Info.Queries
{
    public sealed class InfoResult
    {
        public InfoResult(CurrencyDto[] currencies, CurrentRatesInfoDto ratesInfo)
        {
            Currencies = currencies;
            RatesInfo = ratesInfo;
        }

        public CurrencyDto[] Currencies { get; }

        public CurrentRatesInfoDto RatesInfo { get; }
    }
}
