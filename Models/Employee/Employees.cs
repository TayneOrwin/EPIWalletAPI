using EPIWalletAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EPIWalletAPI.Models.Employee
{
    public class Employees
    {
        [Key]
      public int EmployeeID { get; set; }
      public string Name { get; set; }
      public string Surname { get; set; }
       public int TitlesID { get; set; }
      public virtual Titles Titles { get; set; }




    }
}
