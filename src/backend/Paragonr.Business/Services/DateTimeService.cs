using System;
using Paragonr.Business.Interfaces;

namespace Paragonr.Business.Services
{
    public sealed class DateTimeService : IDateTimeService
    {
        public DateTime Today => DateTime.Today;
    }
}