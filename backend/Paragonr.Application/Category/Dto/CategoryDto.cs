using System;
using Paragonr.Tools.Mapping.Dto;

namespace Paragonr.Application.Category.Dto
{
    public sealed class CategoryDto : EntityBaseDto, IKeyEnabledEntityDto
    {
        public string DomainName { get; set; }

        public Guid Key { get; set; }

        public string Name { get; set; }
    }
}
