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
    public class DSThuongHieuxController : Controller
    {
        private KHOMIPHAMEntities db = new KHOMIPHAMEntities();

        // GET: DSThuongHieux
        public ActionResult Index()
        {
            return View(db.DSThuongHieux.ToList());
        }

        // GET: DSThuongHieux/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSThuongHieu dSThuongHieu = db.DSThuongHieux.Find(id);
            if (dSThuongHieu == null)
            {
                return HttpNotFound();
            }
            return View(dSThuongHieu);
        }

        // GET: DSThuongHieux/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DSThuongHieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThuongHieu,TenTh,XuatXu,DanhGia")] DSThuongHieu dSThuongHieu)
        {
            if (ModelState.IsValid)
            {
                db.DSThuongHieux.Add(dSThuongHieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dSThuongHieu);
        }

        // GET: DSThuongHieux/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSThuongHieu dSThuongHieu = db.DSThuongHieux.Find(id);
            if (dSThuongHieu == null)
            {
                return HttpNotFound();
            }
            return View(dSThuongHieu);
        }

        // POST: DSThuongHieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThuongHieu,TenTh,XuatXu,DanhGia")] DSThuongHieu dSThuongHieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dSThuongHieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dSThuongHieu);
        }

        // GET: DSThuongHieux/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DSThuongHieu dSThuongHieu = db.DSThuongHieux.Find(id);
            if (dSThuongHieu == null)
            {
                return HttpNotFound();
            }
            return View(dSThuongHieu);
        }

        // POST: DSThuongHieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DSThuongHieu dSThuongHieu = db.DSThuongHieux.Find(id);
            db.DSThuongHieux.Remove(dSThuongHieu);
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
