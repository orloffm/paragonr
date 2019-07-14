using Paragonr.Application.Infrastructure;
using Paragonr.Entities;

namespace Paragonr.Application.Currencies
{
    public sealed class CurrencyDto : EntityBaseDto, IMapFrom<Currency>
    {
        public string IsoCode { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }
    }
}