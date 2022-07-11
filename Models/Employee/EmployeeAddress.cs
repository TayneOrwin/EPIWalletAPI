﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Employee
{
    public class EmployeeAddress
    {
        [Key]
        public int AddressID { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Suburb { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public virtual Employees Employee { get; set; }

    }
}