using AccountsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsAPI.Dtos
{
    public class TAccountDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FkAccountType { get; set; }
        public string Createdby { get; set; }
        public string Editby { get; set; }
        //public virtual UserLoginDto FkCreatedbyNavigation { get; set; }
        //public virtual UserLoginDto FkEditbyNavigation { get; set; }
    }
}
