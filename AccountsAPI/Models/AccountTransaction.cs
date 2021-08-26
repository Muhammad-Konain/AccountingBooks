using System;
using System.Collections.Generic;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class AccountTransaction
    {
        public int Id { get; set; }
        public int? FkAccount { get; set; }
        public int? FkGjentry { get; set; }
        public decimal? Amount { get; set; }
        public string Direction { get; set; }

        public virtual TAccount FkAccountNavigation { get; set; }
        public virtual GeneralJournal FkGjentryNavigation { get; set; }
    }
}
