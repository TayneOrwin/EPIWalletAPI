using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class Province
    {
        [Key]
        public int ProvinceID { get; set; }
        public string ProvinceDesctiption { get; set; }
    }
}
