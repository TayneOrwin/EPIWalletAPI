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


  




    }
}
