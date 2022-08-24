using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.ViewModels
{
    public class ReceiptViewModel
    {
        public int ExpenseLineID { get; set; }
        public double amount { get; set; }
        public byte[] file { get; set;}




    }
}
