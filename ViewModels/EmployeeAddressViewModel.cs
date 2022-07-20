using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.ViewModels
{
    public class EmployeeAddressViewModel
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string Suburb { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public int EmployeeID { get; set; }
    }
}
