using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class SponsorType
    {
        [Key]
        public int SponsorTypeID { get; set; }
        public string Description { get; set; }
    }
}
