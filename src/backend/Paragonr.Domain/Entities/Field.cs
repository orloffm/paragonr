using System;
using System.Collections.Generic;
using Paragonr.Tools;

namespace Paragonr.Domain.Entities
{
    public class Field : EntityBase, IKeyEnabledEntity
    {
        public long BudgetId { get; set; }

        public Budget Budget { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public Category DefaultCategory { get; set; }

        public long? DefaultCategoryId { get; set; }

        public string Name { get; set; }

        public Guid Key { get; set; }
    }
}
