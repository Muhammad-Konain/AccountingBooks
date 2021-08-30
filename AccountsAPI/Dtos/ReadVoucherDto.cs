using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsAPI.Dtos
{
    public class ReadVoucherDto
    {
        public int Id { get; set; }
        public int? Vouchertype { get; set; }
        public DateTime? Voucherdate { get; set; }
        public decimal Amount { get; set; }

    }
}
