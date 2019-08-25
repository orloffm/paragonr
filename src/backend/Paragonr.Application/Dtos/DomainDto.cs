using System;
using Paragonr.Application.Infrastructure;

namespace Paragonr.Application.Dtos
{
    public sealed class DomainDto : EntityBaseDto, IKeyEnabledEntityDto
    {
        public string DefaultCategoryName { get; set; }

        public Guid Key { get; set; }

        public string Name { get; set; }
    }
}