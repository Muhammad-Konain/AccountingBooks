using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsAPI.Dtos
{
    public class AccountTransactionDto
    {
        public int? TaccountId { get; set; }
        public decimal? Amount { get; set; }
        public string Direction { get; set; }
    }
}
