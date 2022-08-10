using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class TopUpRequest
    {
        [Key]
        public int TopUpRequestID { get; set; }

        public ExpenseLine ExpenseLine { get; set; }
        public int ExpenseLineID { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }
        public int ApprovalStatusID { get; set; }

        public string Reason { get; set; }
        public double Amount { get; set; }









    }
}
