using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsAPI.Dtos
{
    public class FinancialYearDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool? Status { get; set; }

    }
}
