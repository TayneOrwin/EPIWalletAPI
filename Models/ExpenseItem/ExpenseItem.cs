﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class ExpenseItem
    {
        [Key]
        public virtual ExpenseRequest ExpenseID { get; set; }
        public int ExpenseItemID { get; set; }

        public string itemName { get; set; }

        public double estimateCost { get; set; }
        public string itemDescription { get; set; }







    }
}
