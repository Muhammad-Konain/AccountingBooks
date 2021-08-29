using System;
using System.Collections.Generic;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class AccountTransaction
    {
        public int Id { get; set; }
        public int? TaccountId { get; set; }
        public int? Gjentry { get; set; }
        public decimal? Amount { get; set; }
        public string Direction { get; set; }

        public virtual GeneralJournal GjentryNavigation { get; set; }
        public virtual TAccount Taccount { get; set; }
    }
}
