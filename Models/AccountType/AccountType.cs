using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models
{
    public class AccountType
    {
        [Key]
        public int AccountTypeID { get; set; }

        public string Description { get; set; }
    }
}
