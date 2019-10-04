using Paragonr.Domain.Entities;
using Paragonr.Tools.Mapping;
using Paragonr.Tools.Mapping.Dto;

namespace Paragonr.Application.Currencies
{
    public sealed class CurrencyDto : EntityBaseDto, IMapFrom<Currency>
    {
        public string IsoCode { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }
    }
}
