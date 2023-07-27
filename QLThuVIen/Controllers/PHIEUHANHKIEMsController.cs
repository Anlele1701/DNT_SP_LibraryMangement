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
    public class PHIEUHANHKIEMsController : Controller
    {
        private QLTVEntities db = new QLTVEntities();

        // GET: PHIEUHANHKIEMs
        public ActionResult Index()
        {
            var pHIEUHANHKIEMs = db.PHIEUHANHKIEMs.Include(p => p.DOCGIA);
            return View(pHIEUHANHKIEMs.ToList());
        }

        // GET: PHIEUHANHKIEMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUHANHKIEM pHIEUHANHKIEM = db.PHIEUHANHKIEMs.Find(id);
            if (pHIEUHANHKIEM == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUHANHKIEM);
        }

        // GET: PHIEUHANHKIEMs/Create
        public ActionResult Create()
        {
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA");
            return View();
        }

        // POST: PHIEUHANHKIEMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HK,NGAY,DIEM,LOIVIPHAM,ID_DOCGIA")] PHIEUHANHKIEM pHIEUHANHKIEM)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUHANHKIEMs.Add(pHIEUHANHKIEM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUHANHKIEM.ID_DOCGIA);
            return View(pHIEUHANHKIEM);
        }

        // GET: PHIEUHANHKIEMs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUHANHKIEM pHIEUHANHKIEM = db.PHIEUHANHKIEMs.Find(id);
            if (pHIEUHANHKIEM == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUHANHKIEM.ID_DOCGIA);
            return View(pHIEUHANHKIEM);
        }

        // POST: PHIEUHANHKIEMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HK,NGAY,DIEM,LOIVIPHAM,ID_DOCGIA")] PHIEUHANHKIEM pHIEUHANHKIEM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUHANHKIEM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUHANHKIEM.ID_DOCGIA);
            return View(pHIEUHANHKIEM);
        }

        // GET: PHIEUHANHKIEMs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUHANHKIEM pHIEUHANHKIEM = db.PHIEUHANHKIEMs.Find(id);
            if (pHIEUHANHKIEM == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUHANHKIEM);
        }

        // POST: PHIEUHANHKIEMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUHANHKIEM pHIEUHANHKIEM = db.PHIEUHANHKIEMs.Find(id);
            db.PHIEUHANHKIEMs.Remove(pHIEUHANHKIEM);
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
