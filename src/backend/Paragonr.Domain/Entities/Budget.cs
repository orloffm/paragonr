using System.Collections.Generic;

namespace Paragonr.Domain.Entities
{
    public class Budget : EntityBase
    {
        public string Name { get; set; }

        /// <summary>
        /// Category fields in this budget.
        /// </summary>
        public virtual ICollection<Field> Fields { get; set; }

        /// <summary>
        /// Users that are participants in this budget.
        /// </summary>
        public virtual ICollection<Membership> Memberships { get; set; }

        /// <summary>
        /// All spendings in this budget.
        /// </summary>
        public virtual ICollection<Spending> Spendings { get; set; }
    }
}
