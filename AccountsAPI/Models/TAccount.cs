using System;
using System.Collections.Generic;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class TAccount
    {
        public TAccount()
        {
            AccountTransactions = new HashSet<AccountTransaction>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? FkAccountType { get; set; }
        public DateTime? Createdate { get; set; }
        public int? FkCreatedby { get; set; }
        public int? ParentAccount { get; set; }
        public bool? IsTerminal { get; set; }

        public virtual AccountType FkAccountTypeNavigation { get; set; }
        public virtual User FkCreatedbyNavigation { get; set; }
        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; }
    }
}
