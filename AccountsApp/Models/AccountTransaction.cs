using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsApp.Models
{
    public class AccountTransaction
    {
        [Required]
        public int? TaccountId { get; set; }
        [Required]
        public decimal? Amount { get; set; }
        [Required]
        public string Direction { get; set; }

    }
}
