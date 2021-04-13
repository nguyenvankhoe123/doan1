using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebOnline.Models;

namespace WebOnline.Areas.Administrator.Controllers
{
    public class KhoiLuongSPsController : Controller
    {
        private WebOnlineDbContext db = new WebOnlineDbContext();

        // GET: Administrator/KhoiLuongSPs
        public ActionResult Index()
        {
            return View(db.KhoiLuongSPs.ToList());
        }

        // GET: Administrator/KhoiLuongSPs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoiLuongSP khoiLuongSP = db.KhoiLuongSPs.Find(id);
            if (khoiLuongSP == null)
            {
                return HttpNotFound();
            }
            return View(khoiLuongSP);
        }

        // GET: Administrator/KhoiLuongSPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/KhoiLuongSPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhoiLuong,TenKhoiLuong")] KhoiLuongSP khoiLuongSP)
        {
            if (ModelState.IsValid)
            {
                db.KhoiLuongSPs.Add(khoiLuongSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khoiLuongSP);
        }

        // GET: Administrator/KhoiLuongSPs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoiLuongSP khoiLuongSP = db.KhoiLuongSPs.Find(id);
            if (khoiLuongSP == null)
            {
                return HttpNotFound();
            }
            return View(khoiLuongSP);
        }

        // POST: Administrator/KhoiLuongSPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhoiLuong,TenKhoiLuong")] KhoiLuongSP khoiLuongSP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khoiLuongSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khoiLuongSP);
        }

        // GET: Administrator/KhoiLuongSPs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhoiLuongSP khoiLuongSP = db.KhoiLuongSPs.Find(id);
            if (khoiLuongSP == null)
            {
                return HttpNotFound();
            }
            return View(khoiLuongSP);
        }

        // POST: Administrator/KhoiLuongSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhoiLuongSP khoiLuongSP = db.KhoiLuongSPs.Find(id);
            db.KhoiLuongSPs.Remove(khoiLuongSP);
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
