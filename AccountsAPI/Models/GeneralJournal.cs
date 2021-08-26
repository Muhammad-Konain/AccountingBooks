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
        public DateTime? EntryDate { get; set; }
        public int? FkVoucher { get; set; }

        public virtual Voucher FkVoucherNavigation { get; set; }
        public virtual ICollection<AccountTransaction> AccountTransactions { get; set; }
    }
}
