using Paragonr.Application.Infrastructure;

namespace Paragonr.Application.Dtos
{
    public sealed class CurrencyDto : EntityBaseDto, IMapFrom<Entities.Currency>
    {
        public string IsoCode { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public decimal? RateToMain { get; set; }
    }
}