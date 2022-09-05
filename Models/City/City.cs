using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string CityDesctiption { get; set; }


        public Province Province { get; set; }
        public int ProvinceID { get; set; }

    }
}
