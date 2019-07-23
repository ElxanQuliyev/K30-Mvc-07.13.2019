using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _07._13_2019_mvc_k30.Models;

namespace _07._13_2019_mvc_k30.Areas.Admin.Controllers
{
    public class SectionDivs2RightController : Controller
    {
        private K30FinanceDBEntities db = new K30FinanceDBEntities();

        // GET: Admin/SectionDivs2Right
        public ActionResult Index()
        {
            return View(db.SectionDivs2Right.ToList());
        }

        // GET: Admin/SectionDivs2Right/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionDivs2Right sectionDivs2Right = db.SectionDivs2Right.Find(id);
            if (sectionDivs2Right == null)
            {
                return HttpNotFound();
            }
            return View(sectionDivs2Right);
        }

        // GET: Admin/SectionDivs2Right/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SectionDivs2Right/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Description,Icons")] SectionDivs2Right sectionDivs2Right)
        {
            if (ModelState.IsValid)
            {
                db.SectionDivs2Right.Add(sectionDivs2Right);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sectionDivs2Right);
        }

        // GET: Admin/SectionDivs2Right/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionDivs2Right sectionDivs2Right = db.SectionDivs2Right.Find(id);
            if (sectionDivs2Right == null)
            {
                return HttpNotFound();
            }
            return View(sectionDivs2Right);
        }

        // POST: Admin/SectionDivs2Right/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Description,Icons")] SectionDivs2Right sectionDivs2Right)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sectionDivs2Right).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sectionDivs2Right);
        }

        // GET: Admin/SectionDivs2Right/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionDivs2Right sectionDivs2Right = db.SectionDivs2Right.Find(id);
            if (sectionDivs2Right == null)
            {
                return HttpNotFound();
            }
            return View(sectionDivs2Right);
        }

        // POST: Admin/SectionDivs2Right/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SectionDivs2Right sectionDivs2Right = db.SectionDivs2Right.Find(id);
            db.SectionDivs2Right.Remove(sectionDivs2Right);
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
