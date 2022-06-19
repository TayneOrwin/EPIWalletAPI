using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Employee
{
    public class Employee
    {
        
      public int EmployeeID { get; set; }
      public string Name { get; set; }
      public string Surname { get; set; }
      public string EmailAddress { get; set; }
        public int TitleID { get; set; }
      public virtual Titles Description { get; set; }
      

        
       
    }
}
