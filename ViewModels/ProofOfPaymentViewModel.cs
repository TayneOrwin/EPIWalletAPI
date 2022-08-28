using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.ViewModels
{
    public class ProofOfPaymentViewModel
    {
        public int ExpenseLineID { get; set; }
        public byte[] File { get; set; }
    }
}
