using System;

namespace Paragonr.Application.Interfaces
{
    public interface IRateProvider
    {
        decimal? GetRateOrDefault(string targetIsoCode, string sourceIsoCode, DateTime? date = null);
    }
}