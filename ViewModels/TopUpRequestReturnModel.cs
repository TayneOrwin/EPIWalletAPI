using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.ViewModels
{
    public class TopUpRequestReturnModel
    {

        public int TopUpRequestID { get; set; }
        public int ExpenseLineID { get; set; }
        public double amount { get; set; }
        public string reason { get; set; }
    }
}
