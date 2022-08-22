using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.TopUpRequest
{
    public class TopUpRequestReport
    {
        public int EmployeeID { get; set; }
        public double percentage { get; set; }
        public double amount { get; set; }
        public int TopUpRequestID { get; set; }
        public int ExpenseRequestID { get; set; }
        public double TotalEstimate {get; set;}
        public int ExpenseLineID { get; set; }

    }
}
