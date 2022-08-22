using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class ReasonForRejection
    {
        [Key]
        public int ReasonForRejectionID { get; set; }
        public ApprovalStatus Status { get; set; }
        public int ApprovalID { get; set; }

        public string Reason { get; set; }
    }
}
