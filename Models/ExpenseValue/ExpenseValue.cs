using System;
using System.ComponentModel.DataAnnotations;

namespace EPIWalletAPI.Models.Entities
{
    public class ExpenseValue
    {
        [Key]
        public int valueID { get; set; }
        public int value { get; set; }
    }
}

