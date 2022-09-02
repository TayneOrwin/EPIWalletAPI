using System.ComponentModel.DataAnnotations;

namespace EPIWalletAPI.Models.Entities

{
    public class ProjectCode
    {

        [Key]
        public int ID { get; set; }

        public string code { get; set; }


    }
}
