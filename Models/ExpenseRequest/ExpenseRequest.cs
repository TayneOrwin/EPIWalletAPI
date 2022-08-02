using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EPIWalletAPI.Models.Entities;
using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Employee;
using EPIWalletAPI.Models.Vendor;

namespace EPIWalletAPI.Models

{
    public class ExpenseRequest
    {
        [Key]
        public int ExpenseID { get; set; }
        public virtual ExpenseType TypeID { get; set; }

        public virtual ApprovalStatus ApprovalID { get; set; }

        public virtual Employees EmployeeID { get; set; }

        public virtual Vendors VendorID { get; set; }

        public double totalEstimate { get; set; }

        public ICollection<ExpenseItem> expenseItems { get; set; }


    }
}
