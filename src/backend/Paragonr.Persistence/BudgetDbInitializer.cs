using System;
using System.Collections.Generic;
using System.Linq;
using Paragonr.Entities;

namespace Paragonr.Persistence
{
    public class BudgetDbInitializer
    {
        public static void Initialize(BudgetDbContext context)
        {
            var initializer = new BudgetDbInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(BudgetDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Currencies.Any())
            {
                return;
            }

            AddCurrencies(context);

            AddDefaultCurrencyRates(context);
        }

        private void AddCurrencies(BudgetDbContext context)
        {
            Currency[] currencies =
            {
                new Currency
                {
                    IsoCode = "PLN",
                    Name = "Polish złoty",
                    Symbol = "zł"
                },
                new Currency
                {
                    IsoCode = "USD",
                    Name = "US dollar",
                    Symbol = "$"
                },
                new Currency
                {
                    IsoCode = "EUR",
                    Name = "Euro",
                    Symbol = "€"
                },
                new Currency
                {
                    IsoCode = "RUB",
                    Name = "Russian ruble",
                    Symbol = "₽"
                }
            };

            context.Currencies.AddRange(currencies);

            context.SaveChanges();
        }

        private void AddDefaultCurrencyRates(BudgetDbContext context)
        {
            Dictionary<string, long> currencyIds = context.Currencies.ToDictionary(c => c.IsoCode, c => c.Id);
            var date = new DateTime(2019, 7, 14);

            CurrencyRate MakeRate(string baseCurrencyCode, string targetCurrencyCode, decimal rate)
            {
                return new CurrencyRate
                {
                    BaseId = currencyIds[baseCurrencyCode],
                    TargetId = currencyIds[targetCurrencyCode],
                    Rate = rate,
                    Date = date
                };
            }

            CurrencyRate[] currencyRates =
            {
                MakeRate("PLN", "USD", 3.79m),
                MakeRate("PLN", "EUR", 4.28m),
                MakeRate("PLN", "RUB", 0.0601292m)
            };

            context.CurrencyRates.AddRange(currencyRates);

            context.SaveChanges();
        }
    }
}