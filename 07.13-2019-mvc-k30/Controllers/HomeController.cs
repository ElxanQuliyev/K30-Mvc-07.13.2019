using _07._13_2019_mvc_k30.Models;
using _07._13_2019_mvc_k30.ViewModels.Default;
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
            var defaultModel = new DefaultViewModel()
            {
                topSection = db.TopSection1.First(),
                section2DivsLeft = db.Section2DivsLeft.First(),
                section2DivsRight = db.SectionDivs2Right.ToList(),
                ourProject = db.OurProjectTBs.ToList(),
                client = db.Clients.ToList(),
                blogs = db.RecentNewsTBs.OrderByDescending(b => b.Id).Take(2).ToList(),
        };
         

            return View(defaultModel);
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult BlogDetail(int? id)
        {
            ViewBag.BlogSingle = db.RecentNewsTBs.FirstOrDefault(bl => bl.Id == id);


            if (id==null)
            {
                return HttpNotFound();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(string ClientFullName,string Email,string Header,string Message)
        {
            ViewBag.topSection = db.TopSection1.First();
            ViewBag.section2Left = db.Section2DivsLeft.First();
            ViewBag.section2Right = db.SectionDivs2Right.ToList();
            ViewBag.OurProject = db.OurProjectTBs.ToList();
            Client selectClient = db.Clients.FirstOrDefault(c => c.Email == Email);
            if (selectClient == null)
            {
                //db.Clients.Add(new Client{
                //   Email=ct.Email,
                //   ClientFullName=ct.ClientFullName,
                //   Message=ct.Message,
                //   Header=ct.Header,
                //   Status=0
                //});
                Client client = new Client();
                client.ClientFullName = ClientFullName;
                client.Email = Email;
                client.Header = Header;
                client.Message = Message;
                client.Status = 0;
                db.Clients.Add(client);


                db.SaveChanges();
                ViewBag.Success = "Reyiniz modetorlarimiz terefinden yoxlanilir.Reyiniz üçün teşekkürler";

            }
            else
            {
                ViewBag.Error = "Siz daha öncə rəy bildirmisiniz";
            }
        
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult ProjectDetail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            OurProjectTB ourpro = db.OurProjectTBs.FirstOrDefault(o=>o.Id==id);
            ViewBag.ourPro = ourpro;
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}