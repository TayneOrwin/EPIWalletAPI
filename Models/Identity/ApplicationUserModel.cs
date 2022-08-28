using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPIWalletAPI.Models
{
        public class ApplicationUserModel
        {
        [Key]
        public int ApplicationUserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int accessRole { get; set; }

        public int employeeID { get; set; }
    }
}
