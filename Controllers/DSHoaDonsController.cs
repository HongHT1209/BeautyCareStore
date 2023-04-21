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
    public class DSHoaDonsController : Controller
    {
        private KHOMIPHAMEntities db = new KHOMIPHAMEntities();

        // GET: DSHoaDons
        public ActionResult Index()
        {
            var dSHoaDons = db.DSHoaDons.Include(d => d.DSKhachHang);
            return View(dSHoaDons.ToList());
        }

        // GET: DSHoaDons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSHoaDon dSHoaDon = db.DSHoaDons.Find(id);
            if (dSHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(dSHoaDon);
        }

        // GET: DSHoaDons/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.DSKhachHangs, "MaKH", "TenKH");
            return View();
        }

        // POST: DSHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,NgayLap,MaKH")] DSHoaDon dSHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.DSHoaDons.Add(dSHoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.DSKhachHangs, "MaKH", "TenKH", dSHoaDon.MaKH);
            return View(dSHoaDon);
        }

        // GET: DSHoaDons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSHoaDon dSHoaDon = db.DSHoaDons.Find(id);
            if (dSHoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.DSKhachHangs, "MaKH", "TenKH", dSHoaDon.MaKH);
            return View(dSHoaDon);
        }

        // POST: DSHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,NgayLap,MaKH")] DSHoaDon dSHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dSHoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.DSKhachHangs, "MaKH", "TenKH", dSHoaDon.MaKH);
            return View(dSHoaDon);
        }

        // GET: DSHoaDons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSHoaDon dSHoaDon = db.DSHoaDons.Find(id);
            if (dSHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(dSHoaDon);
        }

        // POST: DSHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DSHoaDon dSHoaDon = db.DSHoaDons.Find(id);
            db.DSHoaDons.Remove(dSHoaDon);
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
