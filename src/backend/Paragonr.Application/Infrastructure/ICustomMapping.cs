using AutoMapper;

namespace Paragonr.Application.Infrastructure
{
    public interface ICustomMapping<TSource, TDestination> : ICustomMapping
    {
    }

    public interface ICustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}