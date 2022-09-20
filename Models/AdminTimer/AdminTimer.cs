using System;
using System.ComponentModel.DataAnnotations;

namespace EPIWalletAPI.Models.Entities
{
    public class AdminTimer
    {

        
            [Key]
            public int timerID { get; set; }
            public int value { get; set; }
        
    }
}

