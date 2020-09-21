using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Media;

namespace Market_Shop.Models
{
    public class productController : Controller
    {
        private ApplicationDbContext _context;

        public productController()
        {
            _context = new ApplicationDbContext();


        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: product
        public ActionResult Index(int? id)
        {
            var product = _context.product.Include(c => c.categroy).ToList();
            return View(product);
        }

        // GET: product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: product/Create
        public ActionResult Create()
        {
            var categroy = _context.categroy.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in categroy)
            {
                list.Add(new SelectListItem() { Text = item.name.ToString(), Value = item.id.ToString() });

            }
            ViewBag.categroy = list;
            return View();
        }

        // POST: product/Create
        [HttpPost]
        public ActionResult Create(product product , HttpPostedFileBase file)
        {
            try
            {
                int lastid = 1;
                if(file != null)
                {
                  
                    if (_context.product.Count() > 0)
                        lastid = _context.product.Max(p => p.id) + 1;


                    var fname = lastid.ToString() + System.IO.Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("/upload/" + fname));

                    product.img = fname;


                }

                _context.product.Add(product);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: product/Edit/5
        public ActionResult Edit(int id )
        {
            var product = _context.product.SingleOrDefault(p => p.id == id) ;
            var categroy = _context.categroy.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in categroy)
            {
                list.Add(new SelectListItem() { Text = item.name, Value = item.id.ToString() });

            }
            ViewBag.categroy = list;
            return View(product);
        }

        // POST: product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, product product , HttpPostedFileBase file)
        {
            try
            {
               
                var productdb = _context.product.SingleOrDefault(p => p.id == id);
              
                if (file != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("/upload/" + productdb.img)))
                        {
                        System.IO.File.Delete(productdb.img);
                    }
                    var fname = file.FileName;
                    file.SaveAs(Server.MapPath("/upload/" + fname));

                    productdb.img = fname;


                }
                productdb.name = product.name;
                productdb.categroyId = product.categroyId;
                productdb.price = product.price;
                productdb.quntity = product.quntity;


                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _context.product.SingleOrDefault(p => p.id == id);


            return View(product);
        }

        // POST: product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, product product)
        {
            try
            {
                var pr = _context.product.SingleOrDefault(p => p.id == id);
                _context.product.Remove(pr);
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
