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
    public class OurProjectTBsController : Controller
    {
        private K30FinanceDBEntities db = new K30FinanceDBEntities();

        // GET: Admin/OurProjectTBs
        public ActionResult Index()
        {
            return View(db.OurProjectTBs.ToList());
        }

        // GET: Admin/OurProjectTBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurProjectTB ourProjectTB = db.OurProjectTBs.Find(id);
            if (ourProjectTB == null)
            {
                return HttpNotFound();
            }
            return View(ourProjectTB);
        }

        // GET: Admin/OurProjectTBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OurProjectTBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,ProjectImage,Description")] OurProjectTB ourProjectTB,HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    WebImage image = new WebImage(Photo.InputStream);
                    FileInfo photoInfo = new FileInfo(Photo.FileName);
                    string newPhoto = Guid.NewGuid().ToString() + photoInfo.Extension;
                    image.Save("~/Uploads/ProjectImage/" + newPhoto);
                    ourProjectTB.ProjectImage = "/Uploads/ProjectImage/" + newPhoto;
                }
                db.OurProjectTBs.Add(ourProjectTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ourProjectTB);
        }

        // GET: Admin/OurProjectTBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurProjectTB ourProjectTB = db.OurProjectTBs.Find(id);
            if (ourProjectTB == null)
            {
                return HttpNotFound();
            }
            return View(ourProjectTB);
        }

        // POST: Admin/OurProjectTBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,ProjectImage,Description")] OurProjectTB ourProjectTB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ourProjectTB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ourProjectTB);
        }

        // GET: Admin/OurProjectTBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurProjectTB ourProjectTB = db.OurProjectTBs.Find(id);
            if (ourProjectTB == null)
            {
                return HttpNotFound();
            }
            return View(ourProjectTB);
        }

        // POST: Admin/OurProjectTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OurProjectTB ourProjectTB = db.OurProjectTBs.Find(id);
            db.OurProjectTBs.Remove(ourProjectTB);
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
