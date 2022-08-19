using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.ViewModels
{
    public class BankingDetailsViewModel
    {
       
        public int AccountTypeID { get; set; }

        public int EmployeeID { get; set; }
        public string AccountNunmber { get; set; }
        public string Branch { get; set; }
        public string Bank { get; set; }
    }
}
