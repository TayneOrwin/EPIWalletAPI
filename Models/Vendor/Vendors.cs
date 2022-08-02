using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace EPIWalletAPI.Models.Vendor
{
    public class Vendors
    {
        [Key]
        public int VendorID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Boolean Availability { get; set; }

    }
}
