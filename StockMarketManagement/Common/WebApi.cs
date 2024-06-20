using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockMarketManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace StockMarketManagement.Common
{
    public class WebApi
    {
        public async static Task<StockDetails> StockDetails(string symbol)
        {

            StockDetails stockDetails = new StockDetails();
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("x-rapidapi-key", "0eeb2a89ccmsh337208b31f46d0bp1489a7jsn4f085626f775");
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "real-time-finance-data.p.rapidapi.com");
            client.BaseAddress = new Uri("https://real-time-finance-data.p.rapidapi.com/");
            var response = await client.GetAsync($"stock-overview?symbol={symbol}&language=en");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                //stockDetails = JsonConvert.DeserializeObject<StockDetails>(data);
                JObject dataobject = JObject.Parse(data);
                var rates = dataobject["data"].ToObject<Dictionary<string, string>>();
                stockDetails.SYMBOL = rates["symbol"];
              
                stockDetails.price = Convert.ToDecimal(rates["price"]);
                stockDetails.open = Convert.ToDecimal(rates["open"]);
                stockDetails.high = Convert.ToDecimal(rates["high"]);
                stockDetails.low = Convert.ToDecimal(rates["low"]);
                stockDetails.volume = Convert.ToDecimal(rates["volume"]);
                stockDetails.previous_close = Convert.ToDouble(rates["previous_close"]);
                stockDetails.change = Convert.ToDecimal(rates["change"]);
                stockDetails.change_percent = Convert.ToDecimal(rates["change_percent"]);
                
            }

            return stockDetails;
        }




    }
}