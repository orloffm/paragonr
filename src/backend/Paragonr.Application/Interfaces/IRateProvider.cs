using System;
using Paragonr.Application.Models;

namespace Paragonr.Application.Interfaces
{
    public interface IRateProvider
    {
        RateInfo GetRateOrDefault(string targetIsoCode, string sourceIsoCode, DateTime? date = null);
    }
}