using System;
using System.Collections.Generic;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class GeneralJournal
    {
        public GeneralJournal()
        {
            AccountTransactions = new HashSet<AccountTransaction>();
        }

        public int Id { get; set; }
        public int? Voucherid { get; set; }
        public int? Entrytypeid { get; set; }

        public virtual EntryType Entrytype { get; set; }
        public virtual Voucher Voucher { get; set; }
        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; }
    }
}
