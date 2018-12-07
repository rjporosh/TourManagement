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
    public class TourPackageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /TourPackage/
        public ActionResult Index()
        {
            var tourpackages = db.TourPackages.Include(t => t.Category).Include(t => t.PackageType);
            return View(tourpackages.ToList());
        }

        // GET: /TourPackage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourPackage tourpackage = db.TourPackages.Find(id);
            if (tourpackage == null)
            {
                return HttpNotFound();
            }
            return View(tourpackage);
        }

        // GET: /TourPackage/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName");
            ViewBag.PackageTypeId = new SelectList(db.PackageTypes, "Id", "PackageName");
            return View();
        }

        // POST: /TourPackage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,AgentName,AgentNo,CompanyName,PackageTypeId,CategoryId,TourPlace,Days,Amount")] TourPackage tourpackage)
        {
            if (ModelState.IsValid)
            {
                db.TourPackages.Add(tourpackage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", tourpackage.CategoryId);
            ViewBag.PackageTypeId = new SelectList(db.PackageTypes, "Id", "PackageName", tourpackage.PackageTypeId);
            return View(tourpackage);
        }

        // GET: /TourPackage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourPackage tourpackage = db.TourPackages.Find(id);
            if (tourpackage == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", tourpackage.CategoryId);
            ViewBag.PackageTypeId = new SelectList(db.PackageTypes, "Id", "PackageName", tourpackage.PackageTypeId);
            return View(tourpackage);
        }

        // POST: /TourPackage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,AgentName,AgentNo,CompanyName,PackageTypeId,CategoryId,TourPlace,Days,Amount")] TourPackage tourpackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourpackage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryName", tourpackage.CategoryId);
            ViewBag.PackageTypeId = new SelectList(db.PackageTypes, "Id", "PackageName", tourpackage.PackageTypeId);
            return View(tourpackage);
        }

        // GET: /TourPackage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourPackage tourpackage = db.TourPackages.Find(id);
            if (tourpackage == null)
            {
                return HttpNotFound();
            }
            return View(tourpackage);
        }

        // POST: /TourPackage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TourPackage tourpackage = db.TourPackages.Find(id);
            db.TourPackages.Remove(tourpackage);
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
