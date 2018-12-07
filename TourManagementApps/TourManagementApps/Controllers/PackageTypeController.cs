using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TourManagementApps.Models;

namespace TourManagementApps.Controllers
{
    [Authorize]
    public class PackageTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /PackageType/
        public ActionResult Index()
        {
            return View(db.PackageTypes.ToList());
        }

        // GET: /PackageType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageType packagetype = db.PackageTypes.Find(id);
            if (packagetype == null)
            {
                return HttpNotFound();
            }
            return View(packagetype);
        }

        // GET: /PackageType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PackageType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,PackageName")] PackageType packagetype)
        {
            if (ModelState.IsValid)
            {
                db.PackageTypes.Add(packagetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(packagetype);
        }

        // GET: /PackageType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageType packagetype = db.PackageTypes.Find(id);
            if (packagetype == null)
            {
                return HttpNotFound();
            }
            return View(packagetype);
        }

        // POST: /PackageType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,PackageName")] PackageType packagetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packagetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(packagetype);
        }

        // GET: /PackageType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageType packagetype = db.PackageTypes.Find(id);
            if (packagetype == null)
            {
                return HttpNotFound();
            }
            return View(packagetype);
        }

        // POST: /PackageType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PackageType packagetype = db.PackageTypes.Find(id);
            db.PackageTypes.Remove(packagetype);
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
