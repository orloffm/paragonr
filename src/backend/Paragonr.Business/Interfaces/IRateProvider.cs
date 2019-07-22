using System;
using Paragonr.Business.Models;

namespace Paragonr.Business.Interfaces
{
    public interface IRateProvider
    {
        RateInfo GetRateOrDefault(string targetIsoCode, string sourceIsoCode, DateTime? date = null);
    }
}