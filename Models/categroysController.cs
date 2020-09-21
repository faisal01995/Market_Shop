using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Market_Shop.Models
{
    public class categroysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: categroys
        public ActionResult Index()
        {
            return View(db.categroy.ToList());
        }

        // GET: categroys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categroy categroy = db.categroy.Find(id);
            if (categroy == null)
            {
                return HttpNotFound();
            }
            return View(categroy);
        }

        // GET: categroys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: categroys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] categroy categroy)
        {
            if (ModelState.IsValid)
            {
                db.categroy.Add(categroy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categroy);
        }

        // GET: categroys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categroy categroy = db.categroy.Find(id);
            if (categroy == null)
            {
                return HttpNotFound();
            }
            return View(categroy);
        }

        // POST: categroys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] categroy categroy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categroy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categroy);
        }

        // GET: categroys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categroy categroy = db.categroy.Find(id);
            if (categroy == null)
            {
                return HttpNotFound();
            }
            return View(categroy);
        }

        // POST: categroys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            categroy categroy = db.categroy.Find(id);
            db.categroy.Remove(categroy);
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
