using System;
using System.Collections.Generic;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class VoucherType
    {
        public VoucherType()
        {
            Vouchers = new HashSet<Voucher>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
