using System.ComponentModel.DataAnnotations;
using System;

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
