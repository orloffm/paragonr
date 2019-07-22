using Paragonr.Application.Infrastructure;
using Paragonr.Entities;

namespace Paragonr.Application.Dtos
{
    public sealed class DomainDto : EntityBaseDto, IMapFrom<Domain>
    {
        public string DefaultCategoryName { get; set; }

        public string Name { get; set; }
    }
}