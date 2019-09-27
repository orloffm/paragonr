using System.Collections.Generic;

namespace Paragonr.Domain.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
    }
}