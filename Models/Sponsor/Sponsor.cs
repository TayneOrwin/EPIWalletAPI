using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class Sponsor
    {
        [Key]
        public int SponsorID { get; set; }

        public int EventID { get; set; }

        public string Event { get; set; }

        public string SponsorType { get; set; }

        public int SponsorTypeID { get; set; }
        public string name { get; set; }
        public string Surname { get; set; }
              
        public double Amount { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }




    }
}
