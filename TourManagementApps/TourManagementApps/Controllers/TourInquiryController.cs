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
    public class TourInquiryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /TourInquiry/
        public ActionResult Index()
        {
            var tourinquiries = db.TourInquiries.Include(t => t.TourPackage);
            return View(tourinquiries.ToList());
        }

        // GET: /TourInquiry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourInquiry tourinquiry = db.TourInquiries.Find(id);
            if (tourinquiry == null)
            {
                return HttpNotFound();
            }
            return View(tourinquiry);
        }

        // GET: /TourInquiry/Create
        public ActionResult Create()
        {
            ViewBag.TourPackageId = new SelectList(db.TourPackages, "Id", "AgentName");
            return View();
        }

        // POST: /TourInquiry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,TourPackageId,Name,ContactNo,Email,City,Comments")] TourInquiry tourinquiry)
        {
            if (ModelState.IsValid)
            {
                db.TourInquiries.Add(tourinquiry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TourPackageId = new SelectList(db.TourPackages, "Id", "AgentName", tourinquiry.TourPackageId);
            return View(tourinquiry);
        }

        // GET: /TourInquiry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourInquiry tourinquiry = db.TourInquiries.Find(id);
            if (tourinquiry == null)
            {
                return HttpNotFound();
            }
            ViewBag.TourPackageId = new SelectList(db.TourPackages, "Id", "AgentName", tourinquiry.TourPackageId);
            return View(tourinquiry);
        }

        // POST: /TourInquiry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,TourPackageId,Name,ContactNo,Email,City,Comments")] TourInquiry tourinquiry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourinquiry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TourPackageId = new SelectList(db.TourPackages, "Id", "AgentName", tourinquiry.TourPackageId);
            return View(tourinquiry);
        }

        // GET: /TourInquiry/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourInquiry tourinquiry = db.TourInquiries.Find(id);
            if (tourinquiry == null)
            {
                return HttpNotFound();
            }
            return View(tourinquiry);
        }

        // POST: /TourInquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TourInquiry tourinquiry = db.TourInquiries.Find(id);
            db.TourInquiries.Remove(tourinquiry);
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
