using System;
using System.Collections.Generic;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class AccountsBook
    {
        public AccountsBook()
        {
            GeneralJournals = new HashSet<GeneralJournal>();
        }

        public int Id { get; set; }
        public int? FKFinancialyear { get; set; }
        public DateTime? Createddate { get; set; }

        public virtual FinancialYear FKFinancialyearNavigation { get; set; }
        public virtual ICollection<GeneralJournal> GeneralJournals { get; set; }
    }
}
