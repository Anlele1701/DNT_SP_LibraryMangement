using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLThuVIen.Models;

namespace QLThuVIen.Controllers
{
    public class NHAXBsController : Controller
    {
        private QLTVEntities db = new QLTVEntities();

        // GET: NHAXBs
        public ActionResult Index()
        {
            return View(db.NHAXBs.ToList());
        }

        // GET: NHAXBs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAXB nHAXB = db.NHAXBs.Find(id);
            if (nHAXB == null)
            {
                return HttpNotFound();
            }
            return View(nHAXB);
        }

        // GET: NHAXBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NHAXBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDNHAXB,TENNHAXB")] NHAXB nHAXB)
        {
            if (ModelState.IsValid)
            {
                db.NHAXBs.Add(nHAXB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHAXB);
        }

        // GET: NHAXBs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAXB nHAXB = db.NHAXBs.Find(id);
            if (nHAXB == null)
            {
                return HttpNotFound();
            }
            return View(nHAXB);
        }

        // POST: NHAXBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDNHAXB,TENNHAXB")] NHAXB nHAXB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHAXB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHAXB);
        }

        // GET: NHAXBs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAXB nHAXB = db.NHAXBs.Find(id);
            if (nHAXB == null)
            {
                return HttpNotFound();
            }
            return View(nHAXB);
        }

        // POST: NHAXBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHAXB nHAXB = db.NHAXBs.Find(id);
            db.NHAXBs.Remove(nHAXB);
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
