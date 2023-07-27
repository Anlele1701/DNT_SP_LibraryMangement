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
    public class TAILIEUxController : Controller
    {
        private QLTVEntities db = new QLTVEntities();

        // GET: TAILIEUx
        public ActionResult Index()
        {
            var tAILIEUx = db.TAILIEUx.Include(t => t.NHAXB).Include(t => t.THELOAI);
            return View(tAILIEUx.ToList());
        }

        // GET: TAILIEUx/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAILIEU tAILIEU = db.TAILIEUx.Find(id);
            if (tAILIEU == null)
            {
                return HttpNotFound();
            }
            return View(tAILIEU);
        }

        // GET: TAILIEUx/Create
        public ActionResult Create()
        {
            ViewBag.IDNHAXB = new SelectList(db.NHAXBs, "IDNHAXB", "TENNHAXB");
            ViewBag.IDTL = new SelectList(db.THELOAIs, "IDTL", "TENTL");
            return View();
        }

        // POST: TAILIEUx/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TAILIEU,TENTAILIEU,TACGIA,HINHANH,SOLUONG,SOTRANG,IDTL,IDNHAXB")] TAILIEU tAILIEU)
        {
            if (ModelState.IsValid)
            {
                db.TAILIEUx.Add(tAILIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDNHAXB = new SelectList(db.NHAXBs, "IDNHAXB", "TENNHAXB", tAILIEU.IDNHAXB);
            ViewBag.IDTL = new SelectList(db.THELOAIs, "IDTL", "TENTL", tAILIEU.IDTL);
            return View(tAILIEU);
        }

        // GET: TAILIEUx/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAILIEU tAILIEU = db.TAILIEUx.Find(id);
            if (tAILIEU == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDNHAXB = new SelectList(db.NHAXBs, "IDNHAXB", "TENNHAXB", tAILIEU.IDNHAXB);
            ViewBag.IDTL = new SelectList(db.THELOAIs, "IDTL", "TENTL", tAILIEU.IDTL);
            return View(tAILIEU);
        }

        // POST: TAILIEUx/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TAILIEU,TENTAILIEU,TACGIA,HINHANH,SOLUONG,SOTRANG,IDTL,IDNHAXB")] TAILIEU tAILIEU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAILIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNHAXB = new SelectList(db.NHAXBs, "IDNHAXB", "TENNHAXB", tAILIEU.IDNHAXB);
            ViewBag.IDTL = new SelectList(db.THELOAIs, "IDTL", "TENTL", tAILIEU.IDTL);
            return View(tAILIEU);
        }

        // GET: TAILIEUx/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAILIEU tAILIEU = db.TAILIEUx.Find(id);
            if (tAILIEU == null)
            {
                return HttpNotFound();
            }
            return View(tAILIEU);
        }

        // POST: TAILIEUx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TAILIEU tAILIEU = db.TAILIEUx.Find(id);
            db.TAILIEUx.Remove(tAILIEU);
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
