using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public ExpenseType Type { get; set; }
        //1-1 relationship 
        public int TypeID { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public DateTime date { get; set; }

        public string projectcodes { get; set; }




    }
}
