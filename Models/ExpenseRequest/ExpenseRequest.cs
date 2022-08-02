using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EPIWalletAPI.Models.Entities;

namespace EPIWalletAPI.Models

{
    public class ExpenseRequest
    {
        [Key]
        public int ExpenseID { get; set; }
        public virtual ExpenseType TypeID { get; set; }

        public virtual ApprovalStatus ApprovalID { get; set; }

        public virtual Employees EmployeeID { get; set; }

        public virtual Vendor VendorID { get; set; }

        public double totalEstimate { get; set; }

        public ICollection<ExpenseItem> expenseItems { get; set; }


    }
}
