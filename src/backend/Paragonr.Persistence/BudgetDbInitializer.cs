using System;
using System.Collections.Generic;
using System.Text;

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

        }
    }
}
