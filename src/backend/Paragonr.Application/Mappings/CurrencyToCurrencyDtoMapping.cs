using AutoMapper;
using Paragonr.Application.Dtos;
using Paragonr.Entities;

namespace Paragonr.Application.Mappings
{
    public sealed class CurrencyToCurrencyDtoMapping : EntityToEntityDtoMappingBase<Currency, CurrencyDto>
    {
        protected override void ConfigureMapping(IMappingExpression<Currency, CurrencyDto> map)
        {
            map.ForMember(d => d.Name, c => c.MapFrom(e => e.Name))
                .ForMember(d => d.Symbol, c => c.MapFrom(e => e.Symbol))
                .ForMember(d => d.IsoCode, c => c.MapFrom(e => e.IsoCode));
        }
    }
}