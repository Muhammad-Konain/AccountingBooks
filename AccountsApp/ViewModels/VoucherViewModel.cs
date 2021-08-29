using AccountsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsApp.ViewModels
{
    public class VoucherViewModel
    {
        public Voucher voucher { get; set; }
        public List<AccountTransaction> transactions { get; set; }
    }
}
