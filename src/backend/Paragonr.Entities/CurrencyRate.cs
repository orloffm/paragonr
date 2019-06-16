using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paragonr.Entities
{
    public class CurrencyRate : EntityBase
    {
        public DateTime Date { get; set; }

        public long TargetId { get; set; }
        public Currency Target { get; set; }

        public long BaseId { get; set; }
        public Currency Base { get; set; }

        public decimal Rate { get; set; }
    }
}