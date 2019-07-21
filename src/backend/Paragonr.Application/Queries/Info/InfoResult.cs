using System.Collections.Generic;
using System.Linq;
using Paragonr.Application.Dtos;

namespace Paragonr.Application.Queries.Info
{
    public sealed class InfoResult
    {
        public InfoResult(IList<CurrencyDto> items)
        {
            Currencies = items.ToArray();
        }

        public CurrencyDto[] Currencies { get; }

        public string MainCurrencyCode { get; }

        public DomainDto[] Domains { get; }

        public CategoryDto[] Categories { get; }
    }
}