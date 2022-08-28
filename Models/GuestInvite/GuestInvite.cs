using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class GuestInvite
    {
        public int id { get; set; }
        public EventInvite EventInvite{get;set;}
        public int? EventInviteID { get; set; }
        public Guest Guest { get; set; }
        public int? GuestID { get; set; }
    }
}
