using AutoMapper;
using Paragonr.Application.Infrastructure;
using Paragonr.Entities;

namespace Paragonr.Application.Mappings
{
    public abstract class EntityToEntityDtoMappingBase<TEntity, TDto> : ICustomMapping<TEntity, TDto> 
        where TEntity: EntityBase
        where TDto: EntityBaseDto

    {
        public void CreateMappings(Profile configuration)
        {
            var expression = configuration.CreateMap<TEntity, TDto>()
                .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(e => e.Id))
                ;

            ConfigureMapping(expression);
        }

        protected abstract void ConfigureMapping(IMappingExpression<TEntity, TDto> map);
    }
}