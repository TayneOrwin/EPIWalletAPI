using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EPIWalletAPI.Models;
using EPIWalletAPI.Models.Vendor;

namespace EPIWalletAPI.Models.Entities

{
    public class ProductCode
    {
        [Key]
        public int CodeID { get; set; }
        public virtual Vendors Vendor { get; set; }
        public int VendorID { get; set; }
        public virtual Event Event { get; set; }
        public int EventID { get; set; }

    }
}
