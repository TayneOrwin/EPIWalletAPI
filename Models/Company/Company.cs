using System.ComponentModel.DataAnnotations;

namespace EPIWalletAPI.Models.Entities
{
    public class Company
    {

        [Key]
        public int CompanyID { get; set; }

        public ProjectCode ProjectCode { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string projectcodes { get; set; }
    }
}
