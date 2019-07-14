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
            LoadSimpleMappings();
            LoadCustomMappings();
        }

        public void LoadSimpleMappings()
        {
            Type[] types = Assembly.GetExecutingAssembly()
                .GetExportedTypes();

            foreach (Type type in types)
            {
                if (type.IsAbstract || type.IsInterface)
                {
                    continue;
                }

                Type[] mapFromInterfaces = type.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))
                    .ToArray();

                foreach (Type mapFromInterface in mapFromInterfaces)
                {
                    Type source = mapFromInterface.GetGenericArguments().First();
                    Type destination = type;

                    CreateMap(source, destination).ReverseMap();
                }
            }
        }

        private void LoadCustomMappings()
        {
        }
    }
}