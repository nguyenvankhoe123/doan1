using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebOnline.Commons;
using WebOnline.Models;

namespace WebOnline.Controllers
{
    public class AccountController : Controller
    {
        WebOnlineDbContext _db = new WebOnlineDbContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            var f_password = FunctionUtils.MD5(Password);
            var user = _db.KhachHangs.Where(x => x.TenDangNhap.Equals(Username) && x.MatKhau.Equals(f_password)).ToList();
            if (user.Count() > 0)
            {

                Session["UserName"] = user.SingleOrDefault().TenDangNhap;
               // return RedirectToAction("/Home/Index");
                return new RedirectResult("/Home/Index");
            }
            else
            {
                ViewBag.error = "Tài khoản hoặc mật khẩu sai!";
                //return new RedirectResult("/Account/Login");
                return RedirectToAction("/Account/Login");
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return View();
        }
        public ActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAccount([Bind(Include = "TenDangNhap,MatKhau,Email,DienThoaiKhach")]KhachHang khachHang )
        {
            if (ModelState.IsValid)
            {
                _db.KhachHangs.Add(khachHang);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}