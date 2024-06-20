using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketManagement.Models.ViewModel
{
    public class StockDetails
    {
        public string SYMBOL { get; set; }
        public decimal price { get; set; }
        public decimal open { get; set; }
        public decimal high { get; set; }
        public decimal low { get; set; }
        public decimal volume { get; set; }
        public double previous_close { get; set; }
        public decimal change { get; set; }
        public decimal change_percent { get; set; }
        public int Userid { get; set; }
      
        public string NAME_OF_COMPANY { get; set; }
        
        public int Quntity { get; set; }
       
        public decimal BuyingPrice { get; set; }
    }
}
