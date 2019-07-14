using System.Collections.Generic;

namespace Paragonr.Entities
{
    public class Category : EntityBase
    {
        public Domain Domain { get; set; }

        public long? DomainId { get; set; }

        public virtual ICollection<Spending> Spendings { get; set; }
    }
}