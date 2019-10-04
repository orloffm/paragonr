using AutoMapper;
using Paragonr.Domain.Entities;

namespace Paragonr.Tools.Mapping.Dto
{
    public abstract class EntityToEntityDtoMappingBase<TEntity, TDto> : ICustomMapping<TEntity, TDto>
        where TEntity : EntityBase where TDto : EntityBaseDto

    {
        public void CreateMappings(Profile configuration)
        {
            IMappingExpression<TEntity, TDto> expression = configuration.CreateMap<TEntity, TDto>();

            ConfigureMapping(expression);
        }

        protected abstract void ConfigureMapping(IMappingExpression<TEntity, TDto> map);
    }
}
