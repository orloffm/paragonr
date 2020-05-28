using AutoMapper;
using Paragonr.Domain.Entities;
using Paragonr.Tools.Mapping.Dto;

namespace Paragonr.Application.Fields
{
    public sealed class FieldToFieldDtoMapping : EntityToEntityDtoMappingBase<Field, FieldDto>
    {
        protected override void ConfigureMapping(IMappingExpression<Field, FieldDto> map)
        {
            map.ForMember(d => d.Name, c => c.MapFrom(e => e.Name))
                .ForMember(d => d.DefaultCategoryName, c => c.MapFrom(e => e.DefaultCategory != null ? e.DefaultCategory.Name : null))
                .ForMember(d => d.Key, c => c.MapFrom(e => e.RefKey));
        }
    }
}
