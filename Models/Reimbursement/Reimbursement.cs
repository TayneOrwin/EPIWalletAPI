using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class Reimbursement
    {
        [Key]
        public int ReimbursementID{get;set;}

        public Reconciliation Reconciliation { get; set; }
        public int ReconID { get; set; }
  
        public double amount { get; set; }


        public DateTime DateTime { get; set; }







    }
}
