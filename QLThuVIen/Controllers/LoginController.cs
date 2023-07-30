using QLThuVIen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLThuVIen.Controllers
{
    public class LoginController : Controller
    {
        QLTVEntities db = new QLTVEntities();
        // GET: Login
        public ActionResult LoginView()
        {
            return View();
        }
        public ActionResult Authen()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authen(NHANVIEN nhanvien)
        {
            var check = db.NHANVIENs.Where(s=>s.EMAIL.Equals(nhanvien.EMAIL)
            && s.MATKHAU.Equals(nhanvien.MATKHAU)).FirstOrDefault();
            if(check == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = check.ID_NHANVIEN;
                Session["Email"] = check.EMAIL;
                Session["HoTen"] = check.HOTENNV.ToString();
                return RedirectToAction("AdminHome", "Home");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("LoginView");
        }
    }
}