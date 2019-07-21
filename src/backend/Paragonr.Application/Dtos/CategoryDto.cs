using Paragonr.Application.Infrastructure;

namespace Paragonr.Application.Dtos
{
    public sealed class CategoryDto : EntityBaseDto
    {
        public string Name { get; set; }

        public string DomainName { get; set; }
    }
}