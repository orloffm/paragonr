using System;

namespace Paragonr.Application.Models
{
    public sealed class RateInfo
    {
        public RateInfo(decimal rate, DateTime date)
        {
            Rate = rate;
            Date = date;
        }

        public DateTime Date { get; }

        public decimal Rate { get; }
    }
}
