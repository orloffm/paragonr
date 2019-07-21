using Paragonr.Application.Infrastructure;

namespace Paragonr.Application.Dtos
{
    public sealed class DomainDto : EntityBaseDto, IMapFrom<Entities.Domain>
    {
        public string Name { get; set; }

        public string DefaultCategoryName { get; set; }
    }
}