namespace EPIWalletAPI.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string UserName { get; set; }    

        public string CurrentPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public string NewPassword { get; set; }

        public int Otp { get; set; }
    }
}
