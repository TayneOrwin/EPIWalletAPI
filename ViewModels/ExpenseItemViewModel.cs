using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.ViewModels
{
    public class ExpenseItemViewModel
    {

        public int ExpenseRequestID { get; set; }

        public string itemName { get; set; }

        public double estimateCost { get; set; }
        public string itemDescription { get; set; }
        public string supplier { get; set; }

       

    }
}
