using _07._13_2019_mvc_k30.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07._13_2019_mvc_k30.Controllers
{
    public class HomeController : Controller
    {
        K30FinanceDBEntities db = new K30FinanceDBEntities();
        public ActionResult Index()
        {
            ViewBag.topSection = db.TopSection1.First();
            ViewBag.section2 = db.Section2Divs.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}