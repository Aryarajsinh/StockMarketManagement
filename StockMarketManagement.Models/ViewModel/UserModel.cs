using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketManagement.Models.ViewModel
{
    public class UserModel
    {
        [Key]
        public int Userid { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Please Enter Currect Password")]
        public string ConformPassword { get; set; }
    }
}
