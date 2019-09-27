using AutoMapper;
using Paragonr.Application.Dtos;
using Paragonr.Domain.Entities;

namespace Paragonr.Application.Mappings
{
    public sealed class CategoryToCategoryDtoMapping : EntityToEntityDtoMappingBase<Category, CategoryDto>
    {
        protected override void ConfigureMapping(IMappingExpression<Category, CategoryDto> map)
        {
            map.ForMember(d => d.Name, c => c.MapFrom(e => e.Name))
                .ForMember(d => d.DomainName, c => c.MapFrom(e => e.Field.Name))
                .ForMember(d => d.Key, c => c.MapFrom(e => e.Key));
        }
    }
}