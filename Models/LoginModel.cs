using System.ComponentModel.DataAnnotations;

namespace EPIWalletAPI.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}
