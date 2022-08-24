
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{


    public class Receipt
    {
        [Key]
        public int ReceiptID { get; set; }
        public byte[] File { get; set; }
        public double amount { get; set; }
        public ExpenseLine ExpenseLine { get; set; }
        public int ExpenseLineID { get; set; }




    }
}
