using System.ComponentModel.DataAnnotations.Schema;

namespace Paragonr.Entities
{
    public class Spending : EntityBase
    {
        public long? CurrencyId { get; set; }

        public Currency Currency { get; set; }

        public decimal Amount { get; set; }

        public long? CategoryId { get; set; }

        public Category Category { get; set; }

        public string Place { get; set; }

        public string Note { get; set; }
    }
}