using StockMarketManagement.Models.DbContext;
using StockMarketManagement.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockMarketManagement.Controllers
{
    public class StockMarketController : Controller
    {
        StockMarketEntities _DbContext = new StockMarketEntities();
        public ActionResult Index()
        {
            StockList SERVICE = new StockList();
            SERVICE.GetStockList();
            return View();
        }
    }
}