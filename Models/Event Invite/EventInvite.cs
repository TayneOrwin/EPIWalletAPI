using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class EventInvitte
    {
        [Key]
        public int InviteID { get; set; }

        public int EventID { get; set; }
        public virtual Event Event { get; set; }



    }
}
