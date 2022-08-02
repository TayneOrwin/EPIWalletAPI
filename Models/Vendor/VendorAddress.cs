using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EPIWalletAPI.Models.Entities;

namespace EPIWalletAPI.Models
{
    public class VendorAddress
    {
        [Key]
        public int VendorAddressID { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string Suburb { get; set; }
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        public int VendorID { get; set; }
        public virtual Vendor Vendor { get; set; }




    }
}
