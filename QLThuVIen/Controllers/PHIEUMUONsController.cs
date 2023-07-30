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
    public class PHIEUMUONsController : Controller
    {
        private QLTVEntities db = new QLTVEntities();

        // GET: PHIEUMUONs
        public ActionResult Index()
        {
            var pHIEUMUONs = db.PHIEUMUONs.Include(p => p.DOCGIA).Include(p => p.TAILIEU);
            return View(pHIEUMUONs.ToList());
        }

        // GET: PHIEUMUONs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUMUON pHIEUMUON = db.PHIEUMUONs.Find(id);
            if (pHIEUMUON == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUMUON);
        }

        // GET: PHIEUMUONs/Create
        public ActionResult Create()
        {
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA");
            ViewBag.ID_TAILIEU = new SelectList(db.TAILIEUx, "ID_TAILIEU", "TENTAILIEU");
            ViewBag.ID_TRASACH = new SelectList(db.PHIEUTRAs, "ID_TRASACH", "TINHTRANG");
            return View();
        }

        // POST: PHIEUMUONs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MUONSACH,NGAYMUON,GHICHU,ID_DOCGIA,ID_TRASACH,ID_TAILIEU")] PHIEUMUON pHIEUMUON)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUMUONs.Add(pHIEUMUON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUMUON.ID_DOCGIA);
            ViewBag.ID_TAILIEU = new SelectList(db.TAILIEUx, "ID_TAILIEU", "TENTAILIEU", pHIEUMUON.ID_TAILIEU);
            //ViewBag.ID_TRASACH = new SelectList(db.PHIEUTRAs, "ID_TRASACH", "TINHTRANG", pHIEUMUON.ID_TRASACH);
            return View(pHIEUMUON);
        }

        // GET: PHIEUMUONs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUMUON pHIEUMUON = db.PHIEUMUONs.Find(id);
            if (pHIEUMUON == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUMUON.ID_DOCGIA);
            ViewBag.ID_TAILIEU = new SelectList(db.TAILIEUx, "ID_TAILIEU", "TENTAILIEU", pHIEUMUON.ID_TAILIEU);
            //ViewBag.ID_TRASACH = new SelectList(db.PHIEUTRAs, "ID_TRASACH", "TINHTRANG", pHIEUMUON.ID_TRASACH);
            return View(pHIEUMUON);
        }

        // POST: PHIEUMUONs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MUONSACH,NGAYMUON,GHICHU,ID_DOCGIA,ID_TRASACH,ID_TAILIEU")] PHIEUMUON pHIEUMUON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUMUON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DOCGIA = new SelectList(db.DOCGIAs, "ID_DOCGIA", "HOTENDOCGIA", pHIEUMUON.ID_DOCGIA);
            ViewBag.ID_TAILIEU = new SelectList(db.TAILIEUx, "ID_TAILIEU", "TENTAILIEU", pHIEUMUON.ID_TAILIEU);
            //ViewBag.ID_TRASACH = new SelectList(db.PHIEUTRAs, "ID_TRASACH", "TINHTRANG", pHIEUMUON.ID_TRASACH);
            return View(pHIEUMUON);
        }

        // GET: PHIEUMUONs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUMUON pHIEUMUON = db.PHIEUMUONs.Find(id);
            if (pHIEUMUON == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUMUON);
        }

        // POST: PHIEUMUONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUMUON pHIEUMUON = db.PHIEUMUONs.Find(id);
            db.PHIEUMUONs.Remove(pHIEUMUON);
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
