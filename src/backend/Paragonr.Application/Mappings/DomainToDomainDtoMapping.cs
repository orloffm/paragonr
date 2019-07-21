using AutoMapper;
using Paragonr.Application.Dtos;
using Paragonr.Entities;

namespace Paragonr.Application.Mappings
{
    public sealed class DomainToDomainDtoMapping : EntityToEntityDtoMappingBase<Domain, DomainDto>
    {
        protected override void ConfigureMapping(IMappingExpression<Domain, DomainDto> map)
        {
            map.ForMember(d => d.Name, c => c.MapFrom(e => e.Name))
                .ForMember(d => d.DefaultCategoryName, c => c.MapFrom(e => e.DefaultCategory != null ? e.DefaultCategory.Name : null));
        }
    }
}