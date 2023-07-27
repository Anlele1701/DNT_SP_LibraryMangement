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
    public class PHIEUPHATsController : Controller
    {
        private QLTVEntities db = new QLTVEntities();

        // GET: PHIEUPHATs
        public ActionResult Index()
        {
            var pHIEUPHATs = db.PHIEUPHATs.Include(p => p.DOCGIA);
            return View(pHIEUPHATs.ToList());
        }

        // GET: PHIEUPHATs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUPHAT pHIEUPHAT = db.PHIEUPHATs.Find(id);
            if (pHIEUPHAT == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUPHAT);
        }

        // GET: PHIEUPHATs/Create
        public ActionResult Create()
        {
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA");
            return View();
        }

        // POST: PHIEUPHATs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPP,PHIPHAT,TINHTRANG,NDVIPHAM,ID_DOCGIA")] PHIEUPHAT pHIEUPHAT)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUPHATs.Add(pHIEUPHAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUPHAT.ID_DOCGIA);
            return View(pHIEUPHAT);
        }

        // GET: PHIEUPHATs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUPHAT pHIEUPHAT = db.PHIEUPHATs.Find(id);
            if (pHIEUPHAT == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUPHAT.ID_DOCGIA);
            return View(pHIEUPHAT);
        }

        // POST: PHIEUPHATs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPP,PHIPHAT,TINHTRANG,NDVIPHAM,ID_DOCGIA")] PHIEUPHAT pHIEUPHAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUPHAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUPHAT.ID_DOCGIA);
            return View(pHIEUPHAT);
        }

        // GET: PHIEUPHATs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUPHAT pHIEUPHAT = db.PHIEUPHATs.Find(id);
            if (pHIEUPHAT == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUPHAT);
        }

        // POST: PHIEUPHATs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUPHAT pHIEUPHAT = db.PHIEUPHATs.Find(id);
            db.PHIEUPHATs.Remove(pHIEUPHAT);
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
