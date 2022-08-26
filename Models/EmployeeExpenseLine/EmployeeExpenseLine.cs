using EPIWalletAPI.Models.Employee;
using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class EmployeeExpenseLine
    {
        [Key]
        public int id { get; set; }
        public Employees Employee { get; set; }
        public int? EmployeeID { get; set; }
        public ExpenseLine ExpenseLine { get; set; }
        public int? ExpenseLineID { get; set; }

    }
}
