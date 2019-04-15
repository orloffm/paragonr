using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paragonr.Entities
{
    public class CurrencyRate : EntityBase
    {
        public DateTime Date { get; set; }

        public long CurrencyId { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; set; }

        [Required]
        [Column(TypeName = "decimal(19, 6)")]
        public decimal RateToMain { get; set; }
    }
}