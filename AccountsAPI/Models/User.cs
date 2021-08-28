using System;
using System.Collections.Generic;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class User
    {
        public User()
        {
            TAccountCreatedbyNavigations = new HashSet<TAccount>();
            TAccountEditbyNavigations = new HashSet<TAccount>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? Status { get; set; }
        public int? FkRoleid { get; set; }

        public virtual UserRole FkRole { get; set; }
        public virtual ICollection<TAccount> TAccountCreatedbyNavigations { get; set; }
        public virtual ICollection<TAccount> TAccountEditbyNavigations { get; set; }
    }
}
