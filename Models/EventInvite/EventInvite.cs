using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class EventInvite
    {


        [Key]
        public int EventInviteID { get; set; }
        public virtual Event Event{ get; set; }
        public int EventID { get; set; }
      
        public string name { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }

        public string address { get; set; }




    }
}
