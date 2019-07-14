using Paragonr.Application.Currencies;

namespace Paragonr.Application.Queries.List
{
    public sealed class CurrencyResult
    {
        public CurrencyResult(CurrencyDto currency)
        {
            Currency = currency;
        }

        public CurrencyDto Currency { get; }
    }
}