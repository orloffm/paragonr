using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

            AddCurrencies(context);

            AddDefaultCurrencyRates(context);

            AddDomainsAndCategories(context);
        }

        private void AddCurrencies(BudgetDbContext context)
        {
            if (context.Currencies.Any())
                return;

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
            if (context.CurrencyRates.Any())
                return;

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

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        private void AddDomainsAndCategories(BudgetDbContext context)
        {
            var domainsAndCategories = new Dictionary<string, string[]>
            {
                {
                    "Дети", new[]
                    {
                        "Одежда",
                        "Еда",
                        "Подгузники",
                        "Развлечения"
                    }
                },
                {
                    "Еда", new[]
                    {
                        "Рестораны",
                        "Снэки"
                    }
                },
                {
                    "Жизнь", new[]
                    {
                        "Квартира",
                        "Медицина",
                        "Путешествия",
                        "Развлечения",
                        "Сервисы",
                        "Страховка",
                        "Транспорт",
                        "Одежда",
                        "Чтение"
                    }
                },
                {
                    "Коты", new string [0]
                },
                {
                    "Машина", new[]
                    {
                        "Бензин",
                        "Парковка",
                        "Обслуживание"
                    }
                }
            };

            if (context.Domains.Any() == false)
            {
                context.Domains.AddRange(domainsAndCategories.Select(kvp => new Domain(){Name = kvp.Key}));
                context.SaveChanges();
            }

            if (context.Categories.Any())
                return;

            var categories = new List<Category>();
            foreach (KeyValuePair<string, string[]> domainAndCategories in domainsAndCategories)
            {
                Domain d = context.Domains.Single(e => e.Name == domainAndCategories.Key);

                var defaultCategory = new Category
                {
                    Domain = d,
                    Name = "-"
                };
                d.DefaultCategory = defaultCategory;
                categories.Add(defaultCategory);

                foreach (string category in domainAndCategories.Value)
                {
                    var c = new Category
                    {
                        Domain = d,
                        Name = category
                    };
                    categories.Add(c);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}