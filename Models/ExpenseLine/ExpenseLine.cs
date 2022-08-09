using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class ExpenseLine
    {
        [Key]
        public int ExpenseLineID { get; set; }
        public int ExpenseRequestID { get; set; }
        public virtual ExpenseRequest ExpenseRequest { get; set; }
     


    }
}
