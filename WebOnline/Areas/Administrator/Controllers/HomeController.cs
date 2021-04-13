using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebOnline.Commons;
using WebOnline.Models;

namespace WebOnline.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        WebOnlineDbContext _db = new WebOnlineDbContext();
        //GET: Administrator/Home

        //public ActionResult Index(string returnUrl)
        //{
        //    LoginModel loginModel = new LoginModel();
        //    if (!string.IsNullOrEmpty(returnUrl)) loginModel.returnUrl = returnUrl;
        //    return View(loginModel);
        //    //return View();
        //}
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            if (ModelState.IsValid)
            {
                var f_password = FunctionUtils.MD5(password);
                var user = _db.USERS.Where(x => x.UserName.Equals(username) && x.PassWord.Equals(f_password)).ToList();
                if (user.Count() > 0)
                {
                    Session["userid"] = user.SingleOrDefault().UserId;
                    Session["UserName"] = user.SingleOrDefault().UserName;
                    Session["Avatar"] = user.SingleOrDefault().Avatar;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Tài khoản hoặc mật khẩu sai!";
                    return new RedirectResult("/Administrator/Home/Login");
                }
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return new RedirectResult("/Login");
        }
 
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        // add md5
        public static string MD5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }

        private static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }

        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("MM/dd/yyyy HH:mm:ss");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}