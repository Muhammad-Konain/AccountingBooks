using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsAPI.Dtos
{
    public class WriteTAccountDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AccountType { get; set; }
        public int? Createdby { get; set; }
        public int? Editby { get; set; }
    }
}
