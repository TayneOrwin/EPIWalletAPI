using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.ViewModels
{
    public class DataTreeViewModel
    {
        public int ProvinceID { get; set; }
        public string Province { get; set; }
        public int CityID { get; set; }
        public string City { get; set; }
        public int SuburbID { get; set; }
        public string Suburb { get; set; }
    }
}
