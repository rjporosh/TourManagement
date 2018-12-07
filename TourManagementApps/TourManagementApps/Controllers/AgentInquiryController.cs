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
    public class AgentInquiryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /AgentInquiry/
        public ActionResult Index()
        {
            var agentinquiries = db.AgentInquiries.Include(a => a.Country);
            return View(agentinquiries.ToList());
        }

        // GET: /AgentInquiry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgentInquiry agentinquiry = db.AgentInquiries.Find(id);
            if (agentinquiry == null)
            {
                return HttpNotFound();
            }
            return View(agentinquiry);
        }

        // GET: /AgentInquiry/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName");
            return View();
        }

        // POST: /AgentInquiry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,CompanyName,Address,City,ZipCode,CountryId,MobileNo,Email,Comments")] AgentInquiry agentinquiry)
        {
            if (ModelState.IsValid)
            {
                db.AgentInquiries.Add(agentinquiry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName", agentinquiry.CountryId);
            return View(agentinquiry);
        }

        // GET: /AgentInquiry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgentInquiry agentinquiry = db.AgentInquiries.Find(id);
            if (agentinquiry == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName", agentinquiry.CountryId);
            return View(agentinquiry);
        }

        // POST: /AgentInquiry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,CompanyName,Address,City,ZipCode,CountryId,MobileNo,Email,Comments")] AgentInquiry agentinquiry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agentinquiry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "CountryName", agentinquiry.CountryId);
            return View(agentinquiry);
        }

        // GET: /AgentInquiry/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgentInquiry agentinquiry = db.AgentInquiries.Find(id);
            if (agentinquiry == null)
            {
                return HttpNotFound();
            }
            return View(agentinquiry);
        }

        // POST: /AgentInquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgentInquiry agentinquiry = db.AgentInquiries.Find(id);
            db.AgentInquiries.Remove(agentinquiry);
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
