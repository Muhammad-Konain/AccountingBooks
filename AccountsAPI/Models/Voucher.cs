using System;
using System.Collections.Generic;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            GeneralJournals = new HashSet<GeneralJournal>();
        }

        public int Id { get; set; }
        public int? Createdby { get; set; }
        public bool? Status { get; set; }
        public int? FkVouchertype { get; set; }

        public virtual VoucherType FkVouchertypeNavigation { get; set; }
        public virtual ICollection<GeneralJournal> GeneralJournals { get; set; }
    }
}
