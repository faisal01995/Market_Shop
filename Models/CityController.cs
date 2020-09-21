using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Market_Shop.Models;
using System.Data.Entity;


namespace Market_Shop.Models
{
    public class CityController : Controller
    {
        // GET: City
        private ApplicationDbContext _context;

        public CityController()
        {
            _context = new ApplicationDbContext();


        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index(int? id )
        {
            var city = _context.City.Include(c => c.Country).ToList();

            if (id != null)
             city = _context.City.Include(c =>c.Country).Where(m=> m.Country_ID == id).ToList();
            return View(city);

        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: City/Create
        public ActionResult Create()
        {
            var Country = _context.Country.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in Country)
            {
                list.Add(new SelectListItem() { Text = item.Country_Name, Value = item.ID.ToString() });
                
            }
            ViewBag.country = list;
            return View();
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(City city)
        {
            try
            {
                _context.City.Add(city);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            var city = _context.City.SingleOrDefault(c => c.ID == id);
            var Country = _context.Country.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in Country)
            {
                list.Add(new SelectListItem() { Text = item.Country_Name, Value = item.ID.ToString() });

            }

            ViewBag.country = list;

            return View();
        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, City city)
        {
            try
            {
                // TODO: Add update logic here

                var cityDB = _context.City.SingleOrDefault(c => c.ID == id);
                cityDB.City_Name = city.City_Name  ;

                cityDB.Country_ID = city.Country_ID ;
                _context.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            var cityDB = _context.City.Include(x => x.Country).SingleOrDefault(c => c.ID == id);
            
            return View(cityDB);
        }

        // POST: City/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var cityDB = _context.City.SingleOrDefault(c => c.ID == id);
                _context.City.Remove(cityDB);
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
