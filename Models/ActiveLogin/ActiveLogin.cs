using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPIWalletAPI.Models.Entities
{
    public class ActiveLogin
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActiveLoginID { get; set; }
        public DateTime date { get; set; }


        public string ApplicationUserID { get; set; }
    }
}
