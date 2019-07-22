using Paragonr.Application.Infrastructure;

namespace Paragonr.Application.Dtos
{
    public sealed class CategoryDto : EntityBaseDto
    {
        public string DomainName { get; set; }

        public string Name { get; set; }
    }
}