using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.ViewModels
{
    public class ExpenseRequestDetailsToView
    {
        public int ApprovalID { get; set; }
        public int ExpenseID { get; set; }
        public int PaymentStatusID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public double TotalEstimate { get; set; }
    }
}
