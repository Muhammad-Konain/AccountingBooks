using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsAPI.Dtos
{
    public class VoucherDto
    {
        public int Id { get; set; }
        public int? Vouchertype { get; set; }
        public int? Entrytypeid { get; set; }
    }
}
