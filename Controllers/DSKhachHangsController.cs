using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeautyCare;

namespace BeautyCare.Controllers
{
    public class DSKhachHangsController : Controller
    {
        private KHOMIPHAMEntities db = new KHOMIPHAMEntities();

        // GET: DSKhachHangs
        public ActionResult Index()
        {
            return View(db.DSKhachHangs.ToList());
        }

        // GET: DSKhachHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSKhachHang dSKhachHang = db.DSKhachHangs.Find(id);
            if (dSKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(dSKhachHang);
        }

        // GET: DSKhachHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DSKhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,TenKH,GioiTinh,DiaChi,SDT,NgaySinh")] DSKhachHang dSKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.DSKhachHangs.Add(dSKhachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dSKhachHang);
        }

        // GET: DSKhachHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSKhachHang dSKhachHang = db.DSKhachHangs.Find(id);
            if (dSKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(dSKhachHang);
        }

        // POST: DSKhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,TenKH,GioiTinh,DiaChi,SDT,NgaySinh")] DSKhachHang dSKhachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dSKhachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dSKhachHang);
        }

        // GET: DSKhachHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSKhachHang dSKhachHang = db.DSKhachHangs.Find(id);
            if (dSKhachHang == null)
            {
                return HttpNotFound();
            }
            return View(dSKhachHang);
        }

        // POST: DSKhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DSKhachHang dSKhachHang = db.DSKhachHangs.Find(id);
            db.DSKhachHangs.Remove(dSKhachHang);
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
