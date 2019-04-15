using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paragonr.Entities
{
    public class Domain : EntityBase
    {
        public string Name { get; set; }

        [InverseProperty(nameof(Category.Domain))]
        public virtual ICollection<Category> Categories { get; set; }

        public long? DefaultCategoryId { get; set; }

        [ForeignKey(nameof(DefaultCategoryId))]
        public Category DefaultCategory { get; set; }
    }
}