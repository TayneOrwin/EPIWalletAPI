using System.ComponentModel.DataAnnotations;

namespace EPIWalletAPI.ViewModels
{
    public class UserViewModel
    {
        [DataType(DataType.EmailAddress)]

        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
