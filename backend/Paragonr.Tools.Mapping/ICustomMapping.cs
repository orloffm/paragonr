using System.Diagnostics.CodeAnalysis;
using AutoMapper;

namespace Paragonr.Tools.Mapping
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