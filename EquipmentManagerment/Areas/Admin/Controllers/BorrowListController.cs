using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EquipmentManagerment.Areas.Admin.Models;
using EquipmentManagerment.Context;

namespace EquipmentManagerment.Areas.Admin.Controllers
{
    public class BorrowListController : Controller
    {
        private EquipmentManangermentEntities1 db = new EquipmentManangermentEntities1();

        // GET: Admin/BorrowList
        public ActionResult Index()
        {
            var nhanVien_ThietBi = db.NhanVien_ThietBi.Include(n => n.NhanVien).Include(n => n.ThietBi);
            return View(nhanVien_ThietBi.ToList());
        }

        // GET: Admin/BorrowList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_ThietBi nhanVien_ThietBi = db.NhanVien_ThietBi.Find(id);
            if (nhanVien_ThietBi == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien_ThietBi);
        }

        // GET: Admin/BorrowList/Create
        public ActionResult Create()
        {
            ViewBag.IDnhanvien = new SelectList(db.NhanViens, "ID", "TenNhanVien");
            ViewBag.IDthietbi = new SelectList(db.ThietBis, "ID", "TenThietBi");
            return View();
        }

        // POST: Admin/BorrowList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDnhanvien,IDthietbi,NgayMuon,NgayTra,Status,ThongTinMoTa")] NhanVien_ThietBi nhanVien_ThietBi)
        {
            if (ModelState.IsValid)
            {
                db.NhanVien_ThietBi.Add(nhanVien_ThietBi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDnhanvien = new SelectList(db.NhanViens, "ID", "TenNhanVien", nhanVien_ThietBi.IDnhanvien);
            ViewBag.IDthietbi = new SelectList(db.ThietBis, "ID", "TenThietBi", nhanVien_ThietBi.IDthietbi);
            //GetDate gd = new GetDate()
            //{
            //    NgayMuon = DateTime.Now,
            //    NgayTra = DateTime.Now.AddDays(1)
            //};
            //return Content(((gd.NgayTra - gd.NgayMuon).TotalDays).ToString());
            return View(nhanVien_ThietBi);
        }

        // GET: Admin/BorrowList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien_ThietBi nhanVien_ThietBi = db.NhanVien_ThietBi.Find(id);
            if (nhanVien_ThietBi == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDnhanvien = new SelectList(db.NhanViens, "ID", "TenNhanVien", nhanVien_ThietBi.IDnhanvien);
            ViewBag.IDthietbi = new SelectList(db.ThietBis, "ID", "TenThietBi", nhanVien_ThietBi.IDthietbi);
            return View(nhanVien_ThietBi);
        }

        // POST: Admin/BorrowList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDnhanvien,IDthietbi,NgayMuon,NgayTra,Status,ThongTinMoTa")] NhanVien_ThietBi nhanVien_ThietBi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien_ThietBi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDnhanvien = new SelectList(db.NhanViens, "ID", "TenNhanVien", nhanVien_ThietBi.IDnhanvien);
            ViewBag.IDthietbi = new SelectList(db.ThietBis, "ID", "TenThietBi", nhanVien_ThietBi.IDthietbi);
            return View(nhanVien_ThietBi);
        }

        // GET: Admin/BorrowList/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //NhanVien_ThietBi nhanVien_ThietBi = db.NhanVien_ThietBi.Find(id);
            //if (nhanVien_ThietBi == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(nhanVien_ThietBi);
            NhanVien_ThietBi nhanVien_ThietBi = db.NhanVien_ThietBi.Find(id);
            db.NhanVien_ThietBi.Remove(nhanVien_ThietBi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Admin/BorrowList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien_ThietBi nhanVien_ThietBi = db.NhanVien_ThietBi.Find(id);
            db.NhanVien_ThietBi.Remove(nhanVien_ThietBi);
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
