
using System;
using System.Linq;
using Paragonr.Application.Interfaces;

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

        public decimal? GetRateOrDefault(string targetIsoCode, string sourceIsoCode, DateTime? date = null)
        {
            DateTime dateToUse = date ?? _dateTime.Today;

            if (targetIsoCode == sourceIsoCode)
                return 1m;

            var allRates = _context.CurrencyRates.Select(
                    r => new
                    {
                        Target = r.Target.IsoCode,
                        Source = r.Base.IsoCode,
                        Date = r.Date,
                        Rate = r.Rate
                    }
                )
                .OrderByDescending(r=>r.Date)
                .Where(r => r.Date <= dateToUse);

            var newestMatch = allRates
                .FirstOrDefault(
                    r => (r.Target == targetIsoCode && r.Source == sourceIsoCode) ||
                         (r.Target == sourceIsoCode && r.Source == targetIsoCode)
                );

            if (newestMatch == null)
                return null;


        }
    }

    public interface IDateTimeService
    {
        DateTime Today { get; }
    }


public sealed    class DateTimeService : IDateTimeService
{
    public DateTime Today => DateTime.Today;
    }}