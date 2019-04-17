using System.ComponentModel.DataAnnotations.Schema;

namespace Paragonr.Entities
{
    public class Category : EntityBase
    {
        public long? DomainId { get; set; }

        [ForeignKey(nameof(DomainId))]
        public Domain Domain { get; set; }
    }
}