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
        public int productCode { get; set; }
        public virtual Vendors VendorID { get; set; }
        public virtual Event EventID { get; set; }

    }
}
