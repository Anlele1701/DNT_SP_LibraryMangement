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
    public class PHIEUTRAsController : Controller
    {
        private QLTVEntities db = new QLTVEntities();

        // GET: PHIEUTRAs
        public ActionResult Index()
        {
            var pHIEUTRAs = db.PHIEUTRAs.Include(p => p.DOCGIA);
            return View(pHIEUTRAs.ToList());
        }

        // GET: PHIEUTRAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTRA pHIEUTRA = db.PHIEUTRAs.Find(id);
            if (pHIEUTRA == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTRA);
        }

        // GET: PHIEUTRAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA");
            return View();
        }

        // POST: PHIEUTRAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TRASACH,NGAYTRA,TINHTRANG,NDVIPHAM,ID_DOCGIA")] PHIEUTRA pHIEUTRA)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUTRAs.Add(pHIEUTRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUTRA.ID_DOCGIA);
            return View(pHIEUTRA);
        }

        // GET: PHIEUTRAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTRA pHIEUTRA = db.PHIEUTRAs.Find(id);
            if (pHIEUTRA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUTRA.ID_DOCGIA);
            return View(pHIEUTRA);
        }

        // POST: PHIEUTRAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TRASACH,NGAYTRA,TINHTRANG,NDVIPHAM,ID_DOCGIA")] PHIEUTRA pHIEUTRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUTRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUTRA.ID_DOCGIA);
            return View(pHIEUTRA);
        }

        // GET: PHIEUTRAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTRA pHIEUTRA = db.PHIEUTRAs.Find(id);
            if (pHIEUTRA == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTRA);
        }

        // POST: PHIEUTRAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUTRA pHIEUTRA = db.PHIEUTRAs.Find(id);
            db.PHIEUTRAs.Remove(pHIEUTRA);
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
