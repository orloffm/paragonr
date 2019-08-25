using System.Collections.Generic;

namespace Paragonr.Entities
{
    public class Budget : EntityBase
    {
        public string Name { get; set; }

        /// <summary>
        /// Category domains in this budget.
        /// </summary>
        public virtual ICollection<Domain> Domains { get; set; }

        /// <summary>
        /// Categories in this budget.
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; }

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