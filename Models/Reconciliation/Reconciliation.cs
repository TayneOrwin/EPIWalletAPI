using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class Reconciliation
    {

        [Key]
        public int ReconID { get; set; }

      

        public int ExpenseLineID { get; set; }
        public ExpenseLine ExpenseLine { get; set; }

        public double Balance { get; set; }




    }
}
