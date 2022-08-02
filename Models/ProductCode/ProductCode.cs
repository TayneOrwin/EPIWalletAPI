using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class ProductCode
    {
        [Key]
        public int productCode { get; set; }
        public virtual Vendor VendorID { get; set; }
        public virtual Event EventID { get; set; }

    }
}
