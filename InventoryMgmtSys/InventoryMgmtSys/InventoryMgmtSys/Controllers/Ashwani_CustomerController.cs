using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryMgmtSys.Data;
using InventoryMgmtSys.Models;

namespace InventoryMgmtSys.Controllers
{
    public class Ashwani_CustomerController : Controller
    {
        private C3IT_DOTNET_TESTEntities13 db = new C3IT_DOTNET_TESTEntities13();

        // GET: Ashwani_Customer
        public ActionResult Index()
        {
            return View(db.Ashwani_Customer.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: Ashwanis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Email,Password")] LoginDTO1 ashwani2)
        {

            Ashwani_Customer ashwani = db.Ashwani_Customer.FirstOrDefault(uv => uv.Email == ashwani2.Email && uv.Password == ashwani2.Password);
            if (ashwani != null)
            {
                return View("WelcomeCustomer");

            }


            return View();
        }
        // GET: Ashwani_Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Customer ashwani_Customer = db.Ashwani_Customer.Find(id);
            if (ashwani_Customer == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_Customer);
        }

        // GET: Ashwani_Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ashwani_Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cus_id,Fname,Lname,Gender,Email,Password,Tel,Address,Cdate")] Ashwani_Customer ashwani_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Ashwani_Customer.Add(ashwani_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ashwani_Customer);
        }

        // GET: Ashwani_Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Customer ashwani_Customer = db.Ashwani_Customer.Find(id);
            if (ashwani_Customer == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_Customer);
        }

        // POST: Ashwani_Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cus_id,Fname,Lname,Gender,Email,Tel,Address,Cdate")] Ashwani_Customer ashwani_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ashwani_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ashwani_Customer);
        }

        // GET: Ashwani_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani_Customer ashwani_Customer = db.Ashwani_Customer.Find(id);
            if (ashwani_Customer == null)
            {
                return HttpNotFound();
            }
            return View(ashwani_Customer);
        }

        // POST: Ashwani_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ashwani_Customer ashwani_Customer = db.Ashwani_Customer.Find(id);
            db.Ashwani_Customer.Remove(ashwani_Customer);
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
