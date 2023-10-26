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
    public class Ashwani_CategoryController : Controller
    {
        private C3IT_DOTNET_TESTEntities13 db = new C3IT_DOTNET_TESTEntities13();

        // GET: Ashwani_Category
        public ActionResult Index()
        {
            return View(db.Ashwani_Category.ToList());
        }

        // GET: Ashwani_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Category ashwani_Category = db.Ashwani_Category.Find(id);
            if (ashwani_Category == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_Category);
        }

        // GET: Ashwani_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ashwani_Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cat_name,cat_comment,cat_date")] Ashwani_Category ashwani_Category)
        {
            if (ModelState.IsValid)
            {
                db.Ashwani_Category.Add(ashwani_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ashwani_Category);
        }

        // GET: Ashwani_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Category ashwani_Category = db.Ashwani_Category.Find(id);
            if (ashwani_Category == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_Category);
        }

        // POST: Ashwani_Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cat_name,cat_comment,cat_date")] Ashwani_Category ashwani_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ashwani_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ashwani_Category);
        }

        // GET: Ashwani_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Category ashwani_Category = db.Ashwani_Category.Find(id);
            if (ashwani_Category == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_Category);
        }

        // POST: Ashwani_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ashwani_Category ashwani_Category = db.Ashwani_Category.Find(id);
            db.Ashwani_Category.Remove(ashwani_Category);
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
