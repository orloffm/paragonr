using System.Diagnostics.CodeAnalysis;
using AutoMapper;

namespace Paragonr.Application.Infrastructure
{
    [SuppressMessage("ReSharper", "UnusedTypeParameter")]
    public interface ICustomMapping<TSource, TDestination> : ICustomMapping
    {
    }

    public interface ICustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}