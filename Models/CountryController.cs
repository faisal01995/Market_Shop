using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Market_Shop.Models;

namespace Market_Shop.Models
{
    public class CountryController : Controller
    {
        private ApplicationDbContext _context;
        public CountryController()
        {
            _context = new ApplicationDbContext();

            
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
                }

        // GET: Country
        public ActionResult Index()
        {
            var country = _context.Country.OrderBy(c => c.Country_Name).ToList();
            return View(country);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            var country = _context.Country.SingleOrDefault(c => c.ID == id);

            return View(country);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(Country Country)
        {
            try
            {
                
                _context.Country.Add(Country);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            var country = _context.Country.SingleOrDefault(c => c.ID == id);

            return View(country);
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Country Country)
        {
            try
            {
                var CountryDb = _context.Country.SingleOrDefault(c => c.ID == id);

                CountryDb.Country_Name = Country.Country_Name;

                _context.SaveChanges();
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            var Count = _context.Country.SingleOrDefault(c => c.ID == id);


            return View(Count);
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Country Country)
        {
            try
            {
                var Coun = _context.Country.SingleOrDefault(c => c.ID == id);

                _context.Country.Remove(Coun);
                _context.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
