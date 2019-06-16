using System.Collections.Generic;

namespace Paragonr.Entities
{
    public class Domain : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public long? DefaultCategoryId { get; set; }

        public Category DefaultCategory { get; set; }
    }
}