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
        public int? AccountType { get; set; }
        public DateTime? Createdate { get; set; }
        public int? Createdby { get; set; }
        public int? ParentAccount { get; set; }
        public bool? IsTerminal { get; set; }
        public int? Editby { get; set; }
        public bool? Status { get; set; }

        public virtual AccountType AccountTypeNavigation { get; set; }
        public virtual User CreatedbyNavigation { get; set; }
        public virtual User EditbyNavigation { get; set; }
        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; }
    }
}
