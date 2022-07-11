using System;

namespace EPIWalletAPI.Models
{
    public class TwoFactorCode
    {
        public string Code { get; set; }
        public DateTime CanBeVerifiedUntil { get; set; }
        public bool IsVerified { get; set; }

        public TwoFactorCode(string code)
        {
            Code = code;
            CanBeVerifiedUntil = DateTime.Now.AddMinutes(5);
            IsVerified = false;
        }
    }
}
