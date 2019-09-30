using System;
using System.Collections.Generic;
using Paragonr.Tools.Domain;

namespace Paragonr.Domain.Entities
{
    public class Category : EntityBase, IRefKeyEnabledEntity
    {
        public Field Field { get; set; }

        public long? DomainId { get; set; }

        public long BudgetId { get; set; }

        public Budget Budget { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Spending> Spendings { get; set; }

        public Guid RefKey { get; set; }
    }
}
