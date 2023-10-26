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
    public class Ashwani_EMployeeController : Controller
    {
        private C3IT_DOTNET_TESTEntities13 db = new C3IT_DOTNET_TESTEntities13();

        // GET: Ashwani_EMployee
        public ActionResult Index()
        {
            return View(db.Ashwani_EMployee.ToList());
        }

        // GET: Ashwani_EMployee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_EMployee ashwani_EMployee = db.Ashwani_EMployee.Find(id);
            if (ashwani_EMployee == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_EMployee);
        }

        // GET: Ashwani_EMployee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ashwani_EMployee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmpName,EmpAddress,EmpAge,EmpSalary,DateOfBirth")] Ashwani_EMployee ashwani_EMployee)
        {
            if (ashwani_EMployee.DateOfBirth > DateTime.Today.Date)
            {
                ModelState.AddModelError("DateOfBirth", "date should not be greater that todays date");
            }
            else if (ModelState.IsValid)
            {
                db.Ashwani_EMployee.Add(ashwani_EMployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ashwani_EMployee);
        }
        public ActionResult Report()
        {
            return View(db.Ashwani_EMployee.ToList());
        }

        // GET: Ashwani_EMployee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_EMployee ashwani_EMployee = db.Ashwani_EMployee.Find(id);
            if (ashwani_EMployee == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_EMployee);
        }

        // POST: Ashwani_EMployee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmpName,EmpAddress,EmpAge,EmpSalary,DateOfBirth")] Ashwani_EMployee ashwani_EMployee)
        {
            if (ashwani_EMployee.DateOfBirth > DateTime.Today.Date)
            {
                ModelState.AddModelError("DateOfBirth", "date should not be greater that todays date");
            }
            else if (ModelState.IsValid)
            {
                db.Entry(ashwani_EMployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ashwani_EMployee);
        }

        // GET: Ashwani_EMployee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_EMployee ashwani_EMployee = db.Ashwani_EMployee.Find(id);
            if (ashwani_EMployee == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_EMployee);
        }

        // POST: Ashwani_EMployee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ashwani_EMployee ashwani_EMployee = db.Ashwani_EMployee.Find(id);
            db.Ashwani_EMployee.Remove(ashwani_EMployee);
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
