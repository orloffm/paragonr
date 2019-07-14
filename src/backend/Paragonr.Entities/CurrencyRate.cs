using System;

namespace Paragonr.Entities
{
    public class CurrencyRate : EntityBase
    {
        public Currency Base { get; set; }

        public long BaseId { get; set; }

        public DateTime Date { get; set; }

        public decimal Rate { get; set; }

        public Currency Target { get; set; }

        public long TargetId { get; set; }
    }
}