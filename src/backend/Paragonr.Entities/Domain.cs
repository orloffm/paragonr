using System.Collections.Generic;

namespace Paragonr.Entities
{
    public class Domain : EntityBase
    {
        public virtual ICollection<Category> Categories { get; set; }

        public Category DefaultCategory { get; set; }

        public long? DefaultCategoryId { get; set; }

        public string Name { get; set; }
    }
}