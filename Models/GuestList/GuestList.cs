using System.ComponentModel.DataAnnotations;

namespace EPIWalletAPI.Models.Entities
{
    public class GuestList
    {
        [Key]
        public int GuestListID { get; set; }

        public string Event { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
