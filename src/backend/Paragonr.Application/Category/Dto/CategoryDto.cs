using System;
using Paragonr.Application.Infrastructure;

namespace Paragonr.Application.Dtos
{
    public sealed class CategoryDto : EntityBaseDto, IKeyEnabledEntityDto
    {
        public string DomainName { get; set; }

        public Guid Key { get; set; }

        public string Name { get; set; }
    }
}