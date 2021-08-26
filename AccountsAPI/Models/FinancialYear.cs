using System;
using System.Collections.Generic;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class FinancialYear
    {
        public FinancialYear()
        {
            AccountsBooks = new HashSet<AccountsBook>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<AccountsBook> AccountsBooks { get; set; }
    }
}
