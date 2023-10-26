using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryMgmtSys.Models;

namespace InventoryMgmtSys.Controllers
{
    public class Ashwani_OrderController : Controller
    {
        private C3IT_DOTNET_TESTEntities13 db = new C3IT_DOTNET_TESTEntities13();

        // GET: Ashwani_Order
        public ActionResult Index()
        {
            var ashwani_Order = db.Ashwani_Order.Include(a => a.Ashwani).Include(a => a.Ashwani_Customer).Include(a => a.Ashwani_Items);
            return View(ashwani_Order.ToList());
        }

        // GET: Ashwani_Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Order ashwani_Order = db.Ashwani_Order.Find(id);
            if (ashwani_Order == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_Order);
        }

        // GET: Ashwani_Order/Create
        public ActionResult Create()
        {
            ViewBag.sales_per = new SelectList(db.Ashwanis, "id", "fname");
            ViewBag.customer = new SelectList(db.Ashwani_Customer, "Id", "Fname");
            ViewBag.itemid = new SelectList(db.Ashwani_Items, "Id", "id_item");
            return View();
        }

        // POST: Ashwani_Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ord_id,ordname,qty,orddate,duedate,manufacturer,sales_per,customer,status,itemid")] Ashwani_Order ashwani_Order)
        {
            Ashwani_Items item = db.Ashwani_Items.FirstOrDefault(x => x.Id == ashwani_Order.itemid);

            if (item != null)
            {
                if (ashwani_Order.qty <= 0)
                {
                    ModelState.AddModelError("qty", "Quantity must be greater than zero.");
                }
                else if (ashwani_Order.qty > item.qty - item.sold_qty)
                {
                    ModelState.AddModelError("qty", "Entered quantity exceeds available stock.");
                }
            }
            else
            {
                ModelState.AddModelError("itemid", "Invalid item selected.");
            }

            // Date validation
            if (ashwani_Order.orddate < DateTime.Today.Date)
            {
                ModelState.AddModelError("orddate", "Order date cannot be in the past.");
            }

            if (ashwani_Order.duedate < ashwani_Order.orddate)
            {
                ModelState.AddModelError("duedate", "Due date must be on or after the order date.");
            }

            if (ModelState.IsValid)
            {
                item.sold_qty = item.sold_qty + ashwani_Order.qty;
                db.Ashwani_Order.Add(ashwani_Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sales_per = new SelectList(db.Ashwanis, "id", "fname", ashwani_Order.sales_per);
            ViewBag.customer = new SelectList(db.Ashwani_Customer, "Id", "Fname", ashwani_Order.customer);
            ViewBag.itemid = new SelectList(db.Ashwani_Items, "Id", "id_item", ashwani_Order.itemid);
            return View(ashwani_Order);
        }


        // GET: Ashwani_Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Order ashwani_Order = db.Ashwani_Order.Find(id);
            if (ashwani_Order == null)
            {
                return HttpNotFound();
            }
            ViewBag.sales_per = new SelectList(db.Ashwanis, "id", "fname", ashwani_Order.sales_per);
            ViewBag.customer = new SelectList(db.Ashwani_Customer, "Id", "Fname", ashwani_Order.customer);
            ViewBag.itemid = new SelectList(db.Ashwani_Items, "Id", "id_item", ashwani_Order.itemid);
            return View(ashwani_Order);
        }

        // POST: Ashwani_Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ord_id,ordname,qty,orddate,duedate,manufacturer,sales_per,customer,status,itemid")] Ashwani_Order ashwani_Order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ashwani_Order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sales_per = new SelectList(db.Ashwanis, "id", "fname", ashwani_Order.sales_per);
            ViewBag.customer = new SelectList(db.Ashwani_Customer, "Id", "Fname", ashwani_Order.customer);
            ViewBag.itemid = new SelectList(db.Ashwani_Items, "Id", "id_item", ashwani_Order.itemid);
            return View(ashwani_Order);
        }

        // GET: Ashwani_Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Order ashwani_Order = db.Ashwani_Order.Find(id);
            if (ashwani_Order == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_Order);
        }

        // POST: Ashwani_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ashwani_Order ashwani_Order = db.Ashwani_Order.Find(id);
            db.Ashwani_Order.Remove(ashwani_Order);
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
