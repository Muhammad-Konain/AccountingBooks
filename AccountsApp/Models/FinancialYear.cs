using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsApp.Models
{
    public class FinancialYear
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool? Status { get; set; }
    }
}
