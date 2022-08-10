﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Entities
{
    public class AccessRole
    {
        [Key]
        public int AccessRoleID { get; set; }
        public string AccessRoleDescription { get; set; }
    }
}
