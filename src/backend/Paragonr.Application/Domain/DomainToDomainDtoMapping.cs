using AutoMapper;
using Paragonr.Application.Dtos;
using Paragonr.Domain.Entities;

namespace Paragonr.Application.Mappings
{
    public sealed class DomainToDomainDtoMapping : EntityToEntityDtoMappingBase<Field, FieldDto>
    {
        protected override void ConfigureMapping(IMappingExpression<Field, FieldDto> map)
        {
            map.ForMember(d => d.Name, c => c.MapFrom(e => e.Name))
                .ForMember(d => d.DefaultCategoryName, c => c.MapFrom(e => e.DefaultCategory != null ? e.DefaultCategory.Name : null))
                .ForMember(d => d.Key, c => c.MapFrom(e => e.Key));
        }
    }
}
