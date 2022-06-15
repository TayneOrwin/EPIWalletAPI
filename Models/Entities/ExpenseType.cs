using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class ExpenseType
    {
        [Key]
        public int TypeID { get; set; }
        public string Type { get; set; }
        public int EventID { get; set; }


        //1-1 relationship
       // public virtual Event Event { get; set; } to be fixed in the event entity, also needs to be 1-n relationship


    }
}
