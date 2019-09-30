using System;
using System.Collections.Generic;
using Paragonr.Tools.Domain;

namespace Paragonr.Domain.Entities
{
    public class User : EntityBase, IRefKeyEnabledEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
        
        public bool IsAdmin { get; set; }

        public Guid RefKey { get; }
    }
}
