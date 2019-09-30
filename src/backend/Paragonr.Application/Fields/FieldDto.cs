using System;
using Paragonr.Tools.Mapping.Dto;

namespace Paragonr.Application.Fields
{
    public sealed class FieldDto : EntityBaseDto, IKeyEnabledEntityDto
    {
        public string DefaultCategoryName { get; set; }

        public Guid Key { get; set; }

        public string Name { get; set; }
    }
}
