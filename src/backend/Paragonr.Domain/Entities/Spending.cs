using System;
using Paragonr.Tools.Domain;

namespace Paragonr.Domain.Entities
{
    public class Spending : EntityBase, IRefKeyEnabledEntity
    {
        public decimal Amount { get; set; }

        public Category Category { get; set; }

        public long? CategoryId { get; set; }

        public Currency Currency { get; set; }

        public long? CurrencyId { get; set; }

        public Budget Budget { get; set; }

        public long? BudgetId { get; set; }

        public User AddedBy { get; set; }

        public long AddedById { get; set; }

        public Guid RefKey { get; set; }

        public string Note { get; set; }

        public string Place { get; set; }
    }
}
