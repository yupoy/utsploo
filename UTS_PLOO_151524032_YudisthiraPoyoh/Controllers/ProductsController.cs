using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UTS_PLOO_151524032_YudisthiraPoyoh.DBContext;
using UTS_PLOO_151524032_YudisthiraPoyoh.Models;

namespace UTS_PLOO_151524032_YudisthiraPoyoh.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDBContext db = new ProductDBContext();

        // GET: Products
        public ActionResult Index(string searchString)
        {
            var product = from m in db.Products select m;
            if (!String.IsNullOrEmpty(searchString)) //findByName
            {
                product = product.Where(s => s.product_name.Contains(searchString));
            }
            if (product.Count() == 0) //findByCategory if findByName not found
            {
                product = from m in db.Products select m;
                if (!String.IsNullOrEmpty(searchString))
                {
                    product = product.Where(s => s.Category.category_name.Contains(searchString));
                }
            }
            if (product.Count() == 0) //findBySupplier if findByCategory not found
            {
                product = from m in db.Products select m;
                if (!String.IsNullOrEmpty(searchString))
                {
                    product = product.Where(s => s.Supplier.supplier_name.Contains(searchString));
                }
            }
            return View(product);
        }

        // GET: Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name");
            ViewBag.supplier_id = new SelectList(db.Suppliers, "supplier_id", "supplier_name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,product_name,price,minimum_stock,supplier_id,category_id")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name", product.category_id);
            ViewBag.supplier_id = new SelectList(db.Suppliers, "supplier_id", "supplier_name", product.supplier_id);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name", product.category_id);
            ViewBag.supplier_id = new SelectList(db.Suppliers, "supplier_id", "supplier_name", product.supplier_id);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,product_name,price,minimum_stock,supplier_id,category_id")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.Categories, "category_id", "category_name", product.category_id);
            ViewBag.supplier_id = new SelectList(db.Suppliers, "supplier_id", "supplier_name", product.supplier_id);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
