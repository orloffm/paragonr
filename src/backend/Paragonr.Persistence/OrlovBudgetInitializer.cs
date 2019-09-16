using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Paragonr.Entities;

namespace Paragonr.Persistence
{
    public class OrlovBudgetInitializer
    {
        private const string BudgetName = "Orlov budget";

        public static void AddCustomOrlovBudgetAndUsers(BudgetDbContext context)
        {
            // Add budget itself.
            if (context.Budgets.Any(b => b.Name == BudgetName))
                return;

            Budget budget = new Budget()
            {
                Name = BudgetName
            };

            context.Budgets.Add(budget);
            context.SaveChanges();

            AddDomainsAndCategories(context, budget);
        }

        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        static void AddDomainsAndCategories(BudgetDbContext context, Budget orlovBudget)
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

            AddDomains(context, orlovBudget, domainsAndCategories);

            AddCategories(context, orlovBudget, domainsAndCategories);

            AddUsers(context, orlovBudget);
        }

        private static void AddUsers(BudgetDbContext context, Budget orlovBudget)
        {
            void AddUser()
            {
                var user = new User()
                {

                };
            }

            

            context.SaveChanges();
        }

        private static void AddCategories(BudgetDbContext context, Budget orlovBudget, Dictionary<string, string[]> domainsAndCategories)
        {
            foreach (KeyValuePair<string, string[]> domainAndCategories in domainsAndCategories)
            {
                Domain d = orlovBudget.Domains.Single(e => e.Name == domainAndCategories.Key);

                void AddCategory(string name, bool isDefault = false)
                {
                    if (d.Categories.Any(c => c.Name == name))
                        return;

                    var category = new Category
                    {
                        Domain = d,
                        Name = name
                    };
                    if (isDefault)
                        d.DefaultCategory = category;
                    context.Categories.Add(category);
                }

                AddCategory("-", true);

                foreach (string category in domainAndCategories.Value)
                {
                    AddCategory(category);
                }
            }

            context.SaveChanges();
        }

        private static void AddDomains(BudgetDbContext context, Budget orlovBudget, Dictionary<string, string[]> domainsAndCategories)
        {
            void AddDomain(string name)
            {
                if (orlovBudget.Domains.Any(d => d.Name == name))
                    return;

                var domain = new Domain()
                {
                    Name = name,
                    Budget = orlovBudget
                };

                context.Domains.Add(domain);
            }

            foreach (string domainName in domainsAndCategories.Select(kvp => kvp.Key))
            {
                AddDomain(domainName);
            }

            context.SaveChanges();
        }
    }
}