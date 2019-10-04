namespace Paragonr.Domain.Entities
{
    public class Membership : EntityBase
    {
        public long BudgetId { get; set; }

        public virtual Budget Budget { get; set; }

        public long UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsManager { get; set; }
    }
}
