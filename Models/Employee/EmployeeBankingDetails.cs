using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Employee
{
    public class EmployeeBankingDetails
    {
        [Key]
        public int BankingDetailsID { get; set; }

        public  AccountType AccountType { get; set; }
        public int AccountTypeID  { get; set; }

        public Employees Employee{ get; set; }
        public int EmployeeID { get; set; }
        public string AccountNunmber { get; set; }
        public string Branch { get; set; }
        public string Bank { get; set; }

    }
}
