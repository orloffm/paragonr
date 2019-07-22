using System;

namespace Paragonr.Application.Queries.Info
{
    public sealed class CurrencyRateInfoDto
    {
        public CurrencyRateInfoDto(string isoCode, decimal rate, DateTime date)
        {
            IsoCode = isoCode;
            Rate = rate;
            Date = date;
        }

        public DateTime Date { get; }

        public string IsoCode { get; }

        public decimal Rate { get; }
    }
}