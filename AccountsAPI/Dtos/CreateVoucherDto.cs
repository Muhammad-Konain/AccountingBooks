using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsAPI.Dtos
{
    public class CreateVoucherDto
    {
        public VoucherDto voucher { get; set; }
        public List<AccountTransactionDto> transactions { get; set; }
    }
}
