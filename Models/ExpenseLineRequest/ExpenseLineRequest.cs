using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class ExpenseLineRequest
    {
        [Key]
        public int id { get; set; }
        public ExpenseRequest Expense { get; set; }
        public int? ExpenseID { get; set; }
        public ExpenseLine ExpenseLine {get;set;}
        public int? ExpenseLineID { get; set; }
    }
}
