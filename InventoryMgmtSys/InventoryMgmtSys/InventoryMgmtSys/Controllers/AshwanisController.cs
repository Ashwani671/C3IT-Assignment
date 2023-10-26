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
    public class AshwanisController : Controller
    {
        private C3IT_DOTNET_TESTEntities13 db = new C3IT_DOTNET_TESTEntities13();

        // GET: Ashwanis
        public ActionResult Index()
        {
            return View(db.Ashwanis.ToList());
        }

        // GET: Ashwanis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani ashwani = db.Ashwanis.Find(id);
            if (ashwani == null)
            {
                return HttpNotFound();
            }
            return View(ashwani);
        }

        // GET: Ashwanis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ashwanis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fname,lname,attname,dob,gender,email,tel,address,user_level,password,udate")] Ashwani ashwani)
        {
            if (ModelState.IsValid)
            {
                db.Ashwanis.Add(ashwani);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ashwani);
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
        public ActionResult Login([Bind(Include = "Email, Password")] Ashwani ashwani)
        {
            // Check if a user with the provided email exists in the database
            Ashwani ashwani1 = db.Ashwanis.FirstOrDefault(u => u.email == ashwani.email);

            if (ashwani1 != null)
            {
                // Check if the password matches
                if (ashwani1.password == ashwani.password)
                {
                    if (ashwani1.user_level == "admin")
                    {
                        return View("Welcome");
                    }
                    else if (ashwani1.user_level == "salesperson")
                    {
                        return View("SalesPerson");
                    }
                }
                else
                {
                    // Password is incorrect
                    ModelState.AddModelError("Password", "Incorrect Password. Please try again.");
                }
            }
            else
            {
                // Email is incorrect
                ModelState.AddModelError("Email", "Email address is not valid.");
            }

            return View(ashwani);
        }

        // GET: Ashwanis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani ashwani = db.Ashwanis.Find(id);
            if (ashwani == null)
            {
                return HttpNotFound();
            }
            return View(ashwani);
        }

        // POST: Ashwanis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fname,lname,attname,dob,gender,email,tel,address,user_level,password,udate")] Ashwani ashwani)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ashwani).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ashwani);
        }

        // GET: Ashwanis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ashwani ashwani = db.Ashwanis.Find(id);
            if (ashwani == null)
            {
                return HttpNotFound();
            }
            return View(ashwani);
        }

        // POST: Ashwanis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ashwani ashwani = db.Ashwanis.Find(id);
            db.Ashwanis.Remove(ashwani);
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

        public ActionResult Logout()
        {
            return View();
        }
    }
}
