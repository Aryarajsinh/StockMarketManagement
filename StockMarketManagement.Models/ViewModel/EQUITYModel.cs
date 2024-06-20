using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketManagement.Models.ViewModel
{
    public class EQUITYModel
    {
       
        public int Userid { get; set; }
        [Required]
        public string SYMBOL { get; set; }
        public string NAME_OF_COMPANY { get; set; }
        [Required]
        public int Quntity { get; set; }
        [Required]
        public decimal BuyingPrice { get; set; }
    }
}
