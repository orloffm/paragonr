using System;

namespace Paragonr.Entities
{
    public class Spending : EntityBase
    {
        public decimal Amount { get; set; }

        public Category Category { get; set; }

        public long? CategoryId { get; set; }

        public Currency Currency { get; set; }

        public long? CurrencyId { get; set; }

        public string Note { get; set; }

        public string Place { get; set; }

        public Guid Key { get; set; }
    }
}