﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.ViewModels
{
    public class SponsorViewModel
    {
   

        public int EventID { get; set; }
        public string name { get; set; }
        public string Surname { get; set; }

        public double Amount { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
    }
}