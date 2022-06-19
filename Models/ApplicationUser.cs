using System.ComponentModel.DataAnnotations.Schema;

namespace EPIWalletAPI.Models
{
    public class ApplicationUser
    {
        [Column(TypeName = "nvarchar(150)")]

        public string Fullname { get; set; }
    }
}
