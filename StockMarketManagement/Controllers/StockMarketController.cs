using StockMarketManagement.Common;
using StockMarketManagement.Models.DbContext;
using StockMarketManagement.Models.ViewModel;
using StockMarketManagement.Repository.Services;
using StockMarketManagement.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StockMarketManagement.Controllers
{
    public class StockMarketController : Controller
    {
        StockMarketEntities _DbContext = new StockMarketEntities();
        StockList service = new StockList();
        public async Task<ActionResult> Index()
        {
            List<StockDetails> listOfstoc = new List<StockDetails>();

           var list = service.GetStockDetails(1);
            for(int i = 0; i < list.Count; i++)
            {
            StockDetails stockDetails = new StockDetails();
               var listobj = await WebApi.StockDetails(list[i].SYMBOL);

                stockDetails.SYMBOL = list[i].SYMBOL;
                stockDetails.price = listobj.price;
                stockDetails.BuyingPrice = list[i].BuyingPrice;
                stockDetails.Quntity = list[i].Quntity;               
                listOfstoc.Add(stockDetails);
            }
           return View(listOfstoc);
        }

        public ActionResult AddStock()
        {

            ViewBag.list = service.GetStockList();
            return View();
        }


        [HttpPost]
        public ActionResult AddStock(EQUITYModel db)
        {
            if (ModelState.IsValid)
            {
                    db.Userid = SessionHelper.GetUserId;
                if (service.AddStocks(db) == 1)
                {
                    Session["Symbol"] = db.SYMBOL;
                    return RedirectToAction("Index");
                }
            }
            return View(db);
        }

    }
}