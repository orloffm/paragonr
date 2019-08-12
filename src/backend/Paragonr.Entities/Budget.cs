using System.Collections.Generic;

namespace Paragonr.Entities
{
    public class Budget : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<User> Members { get; set; }

        public virtual ICollection<Spending> Spendings { get; set; }
    }
}