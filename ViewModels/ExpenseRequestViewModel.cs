using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.ViewModels
{
    public class ExpenseRequestViewModel
    {
     public int EmployeeID { get; set; }
        public  int VendorID { get; set; }
        public int TypeID { get; set; }
        public int ApprovalID { get; set; }
 public int PaymentStatusID { get; set; }
        public double TotalEstimate { get; set; }




    }
}
