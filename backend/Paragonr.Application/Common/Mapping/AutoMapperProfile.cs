using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Paragonr.Tools.Mapping;

namespace Paragonr.Application.Common.Mapping
{
    public sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMappings();
        }

        private void CreateMappings()
        {
            Type[] types = Assembly.GetExecutingAssembly()
                .GetExportedTypes();

            foreach (Type type in types)
            {
                if (type.IsAbstract || type.IsInterface)
                {
                    continue;
                }

                LoadSimpleMappingsFromType(type);

                LoadCustomMappingsFromType(type);
            }
        }

        private void LoadCustomMappingsFromType(Type type)
        {
            var hasCustomInterface = type.GetInterfaces()
                .Any(i => i == typeof(ICustomMapping));

            if (!hasCustomInterface)
            {
                return;
            }

            var instance = (ICustomMapping)Activator.CreateInstance(type);
            instance.CreateMappings(this);
        }

        private void LoadSimpleMappingsFromType(Type type)
        {
            Type[] mapFromInterfaces = type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))
                .ToArray();

            foreach (Type mapFromInterface in mapFromInterfaces)
            {
                Type source = mapFromInterface.GetGenericArguments()
                    .First();
                Type destination = type;

                CreateMap(source, destination)
                    .ReverseMap();
            }
        }
    }
}
