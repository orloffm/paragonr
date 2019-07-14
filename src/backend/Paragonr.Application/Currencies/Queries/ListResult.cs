using System.Collections.Generic;
using Paragonr.Application.Currencies;

namespace Paragonr.Application.Queries.List
{
    public sealed class CurrencyListResult
    {
        public CurrencyListResult(IList<CurrencyDto> items)
        {
            Currencies = items;
        }

        public IList<CurrencyDto> Currencies { get; }
    }
}