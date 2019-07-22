using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Paragonr.Application.Infrastructure
{
    public sealed class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            LoadMappings();
        }

        private void LoadCustomMappingsFromType(Type type)
        {
            bool hasCustomInterface = type.GetInterfaces()
                .Any(i => i == typeof(ICustomMapping));

            if (!hasCustomInterface)
            {
                return;
            }

            var instance = (ICustomMapping) Activator.CreateInstance(type);
            instance.CreateMappings(this);
        }

        private void LoadMappings()
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