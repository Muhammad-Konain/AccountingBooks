using System;
using System.Collections.Generic;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            TAccounts = new HashSet<TAccount>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TAccount> TAccounts { get; set; }
    }
}
