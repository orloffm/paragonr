using System;
using System.Linq;
using Paragonr.Application.Interfaces;
using Paragonr.Application.Models;
using Paragonr.Tools.Interfaces;

namespace Paragonr.Application.Services
{
    public sealed class RateProvider : IRateProvider
    {
        private readonly IBudgetDbContext _context;
        private readonly IDateTimeService _dateTime;

        public RateProvider(IBudgetDbContext context, IDateTimeService dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public RateInfo GetRateOrDefault(string targetIsoCode, string sourceIsoCode, DateTime? date = null)
        {
            DateTime dateToUse = date ?? _dateTime.Today;

            if (targetIsoCode == sourceIsoCode)
            {
                throw new InvalidOperationException("Both currencies are the same.");
            }

            var allRates = _context.CurrencyRates.Select(
                    r => new
                    {
                        Target = r.Target.IsoCode,
                        Source = r.Base.IsoCode,
                        r.Date,
                        r.Rate
                    }
                )
                .Where(
                    r => r.Target == targetIsoCode && r.Source == sourceIsoCode || r.Target == sourceIsoCode && r.Source == targetIsoCode
                )
                .Where(r => r.Date <= dateToUse)
                .OrderByDescending(r => r.Date);

            var newestMatch = allRates.FirstOrDefault();

            if (newestMatch == null)
            {
                return null;
            }

            decimal rate = newestMatch.Rate;

            if (newestMatch.Target == sourceIsoCode)
            {
                rate *= -1;
            }

            return new RateInfo(rate, newestMatch.Date);
        }
    }
}