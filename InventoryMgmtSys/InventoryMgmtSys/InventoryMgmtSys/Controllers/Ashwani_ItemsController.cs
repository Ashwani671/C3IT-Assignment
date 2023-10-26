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
    public class Ashwani_ItemsController : Controller
    {
        private C3IT_DOTNET_TESTEntities13 db = new C3IT_DOTNET_TESTEntities13();

        // GET: Ashwani_Items
        public ActionResult Index()
        {
            var ashwani_Items = db.Ashwani_Items.Include(a => a.Ashwani_Category);
            return View(ashwani_Items.ToList());
        }

        // GET: Ashwani_Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Items ashwani_Items = db.Ashwani_Items.Find(id);
            if (ashwani_Items == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_Items);
        }
        public ActionResult Report()
        {
            var ashwani_Items = db.Ashwani_Items.Include(a => a.Ashwani_Category);
            return View(ashwani_Items.ToList());
        }

        // GET: Ashwani_Items/Create
        public ActionResult Create()
        {
            ViewBag.cat_id = new SelectList(db.Ashwani_Category, "id", "cat_name");
            return View();
        }

        // POST: Ashwani_Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,id_item,itname,qty,sold_qty,cost,itdate,manufacturer,sales_per,address,telephone,itsale,cat_id")] Ashwani_Items ashwani_Items)
        {
            if (ModelState.IsValid)
            {
                db.Ashwani_Items.Add(ashwani_Items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cat_id = new SelectList(db.Ashwani_Category, "id", "cat_name", ashwani_Items.cat_id);
            return View(ashwani_Items);
        }

        // GET: Ashwani_Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Items ashwani_Items = db.Ashwani_Items.Find(id);
            if (ashwani_Items == null)
            {
                return HttpNotFound();
            }
            ViewBag.cat_id = new SelectList(db.Ashwani_Category, "id", "cat_name", ashwani_Items.cat_id);
            return View(ashwani_Items);
        }

        // POST: Ashwani_Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,id_item,itname,qty,sold_qty,cost,itdate,manufacturer,sales_per,address,telephone,itsale,cat_id")] Ashwani_Items ashwani_Items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ashwani_Items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cat_id = new SelectList(db.Ashwani_Category, "id", "cat_name", ashwani_Items.cat_id);
            return View(ashwani_Items);
        }

        // GET: Ashwani_Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Items ashwani_Items = db.Ashwani_Items.Find(id);
            if (ashwani_Items == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_Items);
        }

        // POST: Ashwani_Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ashwani_Items ashwani_Items = db.Ashwani_Items.Find(id);
            db.Ashwani_Items.Remove(ashwani_Items);
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
