using System;
using Paragonr.Tools.Interfaces;

namespace Paragonr.Tools.Services
{
    public sealed class DateTimeService : IDateTimeService
    {
        public DateTime Today => DateTime.Today;
    }
}