using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.EventInvite
{
    public class EventInvite
    {


        [Key]
        public Event EventID { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }

        public string address { get; set; }




    }
}
