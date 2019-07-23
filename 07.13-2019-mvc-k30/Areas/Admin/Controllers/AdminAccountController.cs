using _07._13_2019_mvc_k30.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace _07._13_2019_mvc_k30.Areas.Admin.Controllers
{
    public class AdminAccountController : Controller
    {
        K30FinanceDBEntities db = new K30FinanceDBEntities(); 
        // GET: Admin/AdminAccount
        public ActionResult Login(string Email,string Password)
        {
            if (Email!=string.Empty && Password!=String.Empty)
            {
                Setting adm = db.Settings.Find(1);
                if (adm.AdminEmail==Email && Crypto.VerifyHashedPassword(adm.AdminPassword, Password))
                {
                    Session["adminLogged"] = adm;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Email or password is not correct!";
                }
            }
            else
            {
                ViewBag.Error = "Please all the fill";
            }
           
            return View();
        }
    }
}