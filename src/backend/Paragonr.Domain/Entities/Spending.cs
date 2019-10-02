using System;
using Paragonr.Tools.Domain;

namespace Paragonr.Domain.Entities
{
    public class Spending : EntityBase, IRefKeyEnabledEntity
    {
        public decimal Amount { get; set; }

        public virtual Category Category { get; set; }

        public long? CategoryId { get; set; }

        public virtual Currency Currency { get; set; }

        public long? CurrencyId { get; set; }

        public virtual Budget Budget { get; set; }

        public long? BudgetId { get; set; }

        public virtual User AddedBy { get; set; }

        public long AddedById { get; set; }

        public Guid RefKey { get; set; }

        public string Note { get; set; }

        public string Place { get; set; }
    }
}
