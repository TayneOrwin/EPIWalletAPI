using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities

{
    public class ProofOfPayment
    {
        [Key]
        public int ProofOfPaymentID { get; set; }
        public ExpenseLine ExpenseLine { get; set; }
        public int ExpenseLineID { get; set; }
        public byte[] File { get; set; }
    }

    
}
