using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class Suburb
    {
        [Key]
        public int SuburbID { get; set; }
        public string SuburbDesctiption { get; set; }


        public City City { get; set; }
        public int CityID { get; set; }
    }
}
