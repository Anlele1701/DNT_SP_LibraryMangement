using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using QLThuVIen.Models;

namespace QLThuVIen.Controllers
{
    public class NHANVIENsController : Controller
    {
        private QLTVEntities db = new QLTVEntities();

        // GET: NHANVIENs
        public ActionResult ExportToExcel()
        {
            var NHANVIENs = db.NHANVIENs;
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("NHANVIEN");
                var currentrow = 1;
                worksheet.Cell(currentrow, 1).Value = "ID Nhân viên";
                worksheet.Cell(currentrow, 2).Value = "Họ và tên nhân viên";
                worksheet.Cell(currentrow, 3).Value = "Số điện thoại nhân viên";
                worksheet.Cell(currentrow, 4).Value = "Ngày sinh nhân viên";
                worksheet.Cell(currentrow, 5).Value = "Giới tính nhân viên";
                worksheet.Cell(currentrow, 6).Value = "Chức vụ nhân viên";
                foreach (var hoadon in NHANVIENs)
                {
                    currentrow++;
                    worksheet.Cell(currentrow, 1).Value = hoadon.ID_NHANVIEN;
                    worksheet.Cell(currentrow, 2).Value = hoadon.HOTENNV;
                    worksheet.Cell(currentrow, 3).Value = hoadon.SDT;
                    worksheet.Cell(currentrow, 4).Value = hoadon.NGAYSINH;
                    worksheet.Cell(currentrow, 5).Value = hoadon.GIOITINH;
                    worksheet.Cell(currentrow, 6).Value = hoadon.ROLE;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "NHANVIEN.xlsx"
                        );

                }
            }
        }
        public ActionResult Index()
        {
            return View(db.NHANVIENs.ToList());
        }

        // GET: NHANVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NHANVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NHANVIEN,HOTENNV,MATKHAU,SDT,DIACHI,NGAYSINH,HINHANH,EMAIL,GIOITINH,ROLE")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NHANVIEN,HOTENNV,MATKHAU,SDT,DIACHI,NGAYSINH,HINHANH,EMAIL,GIOITINH,ROLE")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
