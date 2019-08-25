namespace Paragonr.Entities
{
    public class Membership : EntityBase
    {
        public long BudgetId { get; set; }

        public Budget Budget { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public bool IsReadOnly { get; set; }
    }
}