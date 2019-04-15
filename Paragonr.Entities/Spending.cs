using System.ComponentModel.DataAnnotations.Schema;

namespace Paragonr.Entities
{
    public class Spending : EntityBase
    {
        public long? CurrencyId { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal Amount { get; set; }

        public long? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public string Place { get; set; }

        public string Note { get; set; }
    }
}