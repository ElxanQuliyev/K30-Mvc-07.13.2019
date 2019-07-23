using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07._13_2019_mvc_k30.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["AdminLogged"] == null)
            {
                return RedirectToAction("Login", "AdminAccount");
            }
            return View();
        }
    }
}