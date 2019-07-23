using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using _07._13_2019_mvc_k30.Models;

namespace _07._13_2019_mvc_k30.Areas.Admin.Controllers
{
    public class TopSection1Controller : Controller
    {
        private K30FinanceDBEntities db = new K30FinanceDBEntities();

        // GET: Admin/TopSection1
        public ActionResult Index()
        {
            return View(db.TopSection1.ToList());
        }

        // GET: Admin/TopSection1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopSection1 topSection1 = db.TopSection1.Find(id);
            if (topSection1 == null)
            {
                return HttpNotFound();
            }
            return View(topSection1);
        }

        // GET: Admin/TopSection1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TopSection1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,Header,Description,btnText")] TopSection1 topSection1)
        {
            if (ModelState.IsValid)
            {
                db.TopSection1.Add(topSection1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topSection1);
        }

        // GET: Admin/TopSection1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopSection1 topSection1 = db.TopSection1.Find(id);
            if (topSection1 == null)
            {
                return HttpNotFound();
            }
            return View(topSection1);
        }

        // POST: Admin/TopSection1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[Bind(Include = "Id,Image,Header,Description,btnText")] TopSection1 topSection1,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                TopSection1 selected = db.TopSection1.SingleOrDefault(nt => nt.Id == id);
                if (Image != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(topSection1.Image)))
                    {
                        System.IO.File.Delete(Server.MapPath(topSection1.Image));
                    }
                    WebImage image = new WebImage(Image.InputStream);
                    FileInfo photoInfo = new FileInfo(Image.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    image.Save("~/Uploads/TopSectionImage/" + newPhoto);
                    selected.Image = "/Uploads/TopSectionImage/" + newPhoto;
                }
                selected.Header = topSection1.Header;
                selected.Description = topSection1.Header;
                selected.btnText = topSection1.btnText;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topSection1);
        }

        // GET: Admin/TopSection1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TopSection1 topSection1 = db.TopSection1.Find(id);
            if (topSection1 == null)
            {
                return HttpNotFound();
            }
            return View(topSection1);
        }

        // POST: Admin/TopSection1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TopSection1 topSection1 = db.TopSection1.Find(id);
            db.TopSection1.Remove(topSection1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
