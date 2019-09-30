using AutoMapper;
using Paragonr.Tools.Mapping.Dto;

namespace Paragonr.Application.Category.Dto
{
    public sealed class CategoryToCategoryDtoMapping : EntityToEntityDtoMappingBase<Domain.Entities.Category, CategoryDto>
    {
        protected override void ConfigureMapping(IMappingExpression<Domain.Entities.Category, CategoryDto> map)
        {
            map.ForMember(d => d.Name, c => c.MapFrom(e => e.Name))
                .ForMember(d => d.DomainName, c => c.MapFrom(e => e.Field.Name))
                .ForMember(d => d.Key, c => c.MapFrom(e => e.RefKey));
        }
    }
}
