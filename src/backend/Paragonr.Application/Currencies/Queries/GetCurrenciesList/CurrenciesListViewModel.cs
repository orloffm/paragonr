using System.Collections.Generic;

namespace Paragonr.Application.Currencies.Queries.GetCurrenciesList
{
    public sealed class CurrenciesListViewModel
    {
        public IList<CurrencyDto> Currencies { get; set; }
    }
}