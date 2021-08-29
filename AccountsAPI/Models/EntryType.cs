using System;
using System.Collections.Generic;

#nullable disable

namespace AccountsAPI.Models
{
    public partial class EntryType
    {
        public EntryType()
        {
            GeneralJournals = new HashSet<GeneralJournal>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<GeneralJournal> GeneralJournals { get; set; }
    }
}
