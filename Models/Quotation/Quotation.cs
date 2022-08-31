using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class Quotation
    {
        [Key]
        public int QuotationID { get; set; }
        public ExpenseItem ExpenseItem { get; set; }
        public int ExpenseItemID { get; set; }
        public byte[] File { get; set; }

    }
}
