using EPIWalletAPI.Models.Employee;
using EPIWalletAPI.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace EPIWalletAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(150)")]

        public virtual Entities.AccessRole AccessRole { get; set; }
        public int AccessRoleID { get; set; }

        public virtual Employees Employee { get; set; }
        public int EmployeeID { get; set; }

    }
}
