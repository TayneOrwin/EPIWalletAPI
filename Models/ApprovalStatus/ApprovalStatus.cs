using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class ApprovalStatus
    {
        [Key]
        public int ApprovalID { get; set; }
        public string status { get; set; }



    }
}
