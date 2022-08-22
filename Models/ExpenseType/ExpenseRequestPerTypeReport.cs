using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.ExpenseType
{
    public class ExpenseRequestPerTypeReport
    {
        public string Type { get; set; }
        public int Requests { get; set; }
    }
}
