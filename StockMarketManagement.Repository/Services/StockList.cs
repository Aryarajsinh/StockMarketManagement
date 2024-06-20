using StockMarketManagement.Models.DbContext;
using StockMarketManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketManagement.Repository.Services
{
    public class StockList
    {
       StockMarketEntities _dbContext = new StockMarketEntities();
        public List<EQUITYModel> GetStockList()
        {
            var list =_dbContext.Database.SqlQuery<EQUITYModel>("Exec GeTStockList").ToList();
            return list;
        }
        public int AddStocks(EQUITYModel db)
        {
            
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Userid",db.Userid),
                new SqlParameter("@Stocks",db.SYMBOL),
                new SqlParameter("@Quntity",db.Quntity),
                new SqlParameter("@BuyingPrice",db.BuyingPrice),

            };
            _dbContext.Database.SqlQuery<EQUITYModel>("Exec InsertRecord @Userid,@Stocks,@Quntity,@BuyingPrice", sqlParameters).ToList();
            return 1;
        }
        public List<EQUITYModel> GetStockDetails(int userid)
        {
            SqlParameter[] stockdetails = new SqlParameter[]
            {
                new SqlParameter("@userid",Convert.ToInt32(userid))            

            };
            var list =_dbContext.Database.SqlQuery<EQUITYModel>("Exec getStockDetails @userid", stockdetails).ToList();
            return list ;
        }


    }
}
