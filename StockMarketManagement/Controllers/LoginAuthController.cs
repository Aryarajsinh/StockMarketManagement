using StockMarketManagement.Models.DbContext;
using StockMarketManagement.Models.ViewModel;
using StockMarketManagement.Session;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockMarketManagement.Controllers
{
    public class LoginAuthController : Controller
    {
        StockMarketEntities _opetion = new StockMarketEntities();
        public ActionResult Login()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Login(LoginModel db)
        {
            var userlist = _opetion.UserTable.FirstOrDefault(m => m.Email == db.Email);
            if (ModelState.IsValid && userlist.Email == db.Email && userlist.Password == db.Password)
            {
                SessionHelper.LoggedInUser = userlist.Username;
                SessionHelper.GetUserId = userlist.Userid;
                Session["Username"] = SessionHelper.LoggedInUser;
                return RedirectToAction("Index", "StockMarket");
            }
            else
            {
                return View(db);
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModel db)
        {
            var IsemailExist = _opetion.UserTable.Any(m => m.Email == db.Email);
            if (ModelState.IsValid && !IsemailExist)
            {

                SqlParameter[] registeruser = new SqlParameter[]
                {
                    new SqlParameter("@username",db.Username),
                    new SqlParameter("@email",db.Email),
                    new SqlParameter("@passward",db.Password)                   
                };

                _opetion.Database.SqlQuery<UserModel>("Exec RegisterUser @username,@email,@passward", registeruser).ToList();
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Logout()
        {
            try
            {
                SessionHelper.Logout();
                
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}