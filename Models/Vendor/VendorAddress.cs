using System.ComponentModel.DataAnnotations;

namespace EPIWalletAPI.Models.Vendor
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
        public virtual Vendors Vendor { get; set; }
    }
}