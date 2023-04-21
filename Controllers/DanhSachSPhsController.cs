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
    public class DanhSachSPhsController : Controller
    {
        private KHOMIPHAMEntities db = new KHOMIPHAMEntities();

        // GET: DanhSachSPhs
        public ActionResult Index()
        {
            var danhSachSPhs = db.DanhSachSPhs.Include(d => d.DSThuongHieu).Include(d => d.PhanLoai);
            return View(danhSachSPhs.ToList());
        }

        // GET: DanhSachSPhs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachSPh danhSachSPh = db.DanhSachSPhs.Find(id);
            if (danhSachSPh == null)
            {
                return HttpNotFound();
            }
            return View(danhSachSPh);
        }

        // GET: DanhSachSPhs/Create
        public ActionResult Create()
        {
            ViewBag.MaThuongHieu = new SelectList(db.DSThuongHieux, "MaThuongHieu", "TenTh");
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "LoaiSP");
            return View();
        }

        // POST: DanhSachSPhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,MaPhanLoai,TenSP,DonGia,KhoiLuong,SoLuong,GioiThieu,MaThuongHieu")] DanhSachSPh danhSachSPh)
        {
            if (ModelState.IsValid)
            {
                db.DanhSachSPhs.Add(danhSachSPh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaThuongHieu = new SelectList(db.DSThuongHieux, "MaThuongHieu", "TenTh", danhSachSPh.MaThuongHieu);
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "LoaiSP", danhSachSPh.MaPhanLoai);
            return View(danhSachSPh);
        }

        // GET: DanhSachSPhs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachSPh danhSachSPh = db.DanhSachSPhs.Find(id);
            if (danhSachSPh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaThuongHieu = new SelectList(db.DSThuongHieux, "MaThuongHieu", "TenTh", danhSachSPh.MaThuongHieu);
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "LoaiSP", danhSachSPh.MaPhanLoai);
            return View(danhSachSPh);
        }

        // POST: DanhSachSPhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,MaPhanLoai,TenSP,DonGia,KhoiLuong,SoLuong,GioiThieu,MaThuongHieu")] DanhSachSPh danhSachSPh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhSachSPh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaThuongHieu = new SelectList(db.DSThuongHieux, "MaThuongHieu", "TenTh", danhSachSPh.MaThuongHieu);
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "LoaiSP", danhSachSPh.MaPhanLoai);
            return View(danhSachSPh);
        }

        // GET: DanhSachSPhs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachSPh danhSachSPh = db.DanhSachSPhs.Find(id);
            if (danhSachSPh == null)
            {
                return HttpNotFound();
            }
            return View(danhSachSPh);
        }

        // POST: DanhSachSPhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DanhSachSPh danhSachSPh = db.DanhSachSPhs.Find(id);
            db.DanhSachSPhs.Remove(danhSachSPh);
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
