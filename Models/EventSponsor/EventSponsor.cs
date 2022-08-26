using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    
    public class EventSponsor
    {
        [Key]
        public int id { get; set; }
        
        public Event Event { get; set; }
        public int? EventID { get; set; }
         
        public Sponsor Sponsor { get; set; }

        public int? SponsorID { get; set; }
    }
}
