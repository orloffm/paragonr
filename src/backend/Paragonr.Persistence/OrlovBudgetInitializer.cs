using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Paragonr.Domain.Entities;

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

            var budget = context.Budgets.FirstOrDefault(b => b.Name == BudgetName);

            if (budget == null)
            {
                budget = new Budget()
                {
                    Name = BudgetName
                };

                context.Budgets.Add(budget);
                context.SaveChanges();
            }

            AddDomainsAndCategories(context, budget);

            AddUsers(context, budget);
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
        }

        private static void AddUsers(BudgetDbContext context, Budget orlovBudget)
        {
            void AddUser(string firstName, string lastName, string email, string login, string password)
            {
                User user = context.Users.FirstOrDefault(u => u.Username == login);

                if (user != null)
                {
                    return;
                }

                user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Username = login,
                    PasswordHash = password != null ? Encoding.UTF8.GetBytes(password) : null,
                    PasswordSalt = null
                };

                var membership = new Membership()
                {
                    User = user,
                    Budget = orlovBudget,
                    IsManager = true
                };

                context.Users.Add(user);
                context.Memberships.Add(membership);
                context.SaveChanges();
            }

            AddUser("Mikhail", "Orlov", "orloffm@gmail.com", "orloffm", null);
            AddUser("Ekaterina", "Orlova", "egogotha@gmail.com", "egogotha", null);
        }

        private static void AddCategories(BudgetDbContext context, Budget orlovBudget, Dictionary<string, string[]> domainsAndCategories)
        {
            foreach (KeyValuePair<string, string[]> domainAndCategories in domainsAndCategories)
            {
                var d = orlovBudget.Fields.Single(e => e.Name == domainAndCategories.Key);

                void AddCategory(string name, bool isDefault = false)
                {
                    if (d.Categories?.Any(c => c.Name == name) == true)
                    {
                        return;
                    }

                    var category = new Category
                    {
                        Field = d,
                        Name = name
                    };

                    if (isDefault)
                    {
                        d.DefaultCategory = category;
                    }

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
                if (orlovBudget.Fields?.Any(d => d.Name == name) == true)
                {
                    return;
                }

                var domain = new Field()
                {
                    Name = name,
                    Budget = orlovBudget
                };

                context.Fields.Add(domain);
            }

            foreach (string domainName in domainsAndCategories.Select(kvp => kvp.Key))
            {
                AddDomain(domainName);
            }

            context.SaveChanges();
        }
    }
}
