using System;
using Paragonr.Shared.Interfaces;

namespace Paragonr.Shared.Services
{
    public sealed class DateTimeService : IDateTimeService
    {
        public DateTime Today => DateTime.Today;
    }
}