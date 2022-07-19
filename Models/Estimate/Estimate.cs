using System.ComponentModel.DataAnnotations;

namespace EPIWalletAPI.Models.Estimate
{
    public class Estimates
    {
        [Key]
        public int EstimateID { get; set; }

        public int Amount { get; set; }
    }
}
