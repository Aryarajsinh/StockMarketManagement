using StockMarketManagement.Models.DbContext;
using StockMarketManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketManagement.Repository.Services
{
    public class StockList
    {
       StockMarketEntities _dbContext = new StockMarketEntities();
        public void GetStockList()
        {
            var list =_dbContext.Database.SqlQuery<EQUITYModel>("Exec GeTStockList").ToList();

        }
    }
}
