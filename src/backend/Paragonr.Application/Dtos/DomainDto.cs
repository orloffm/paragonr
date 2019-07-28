using System;
using Paragonr.Application.Infrastructure;
using Paragonr.Entities;

namespace Paragonr.Application.Dtos
{
    public sealed class DomainDto : EntityBaseDto, IKeyEnabledEntityDto
    {
        public string DefaultCategoryName { get; set; }

        public string Name { get; set; }

        public Guid Key { get; set; }
    }
}