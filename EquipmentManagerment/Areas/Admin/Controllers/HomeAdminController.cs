using EquipmentManagerment.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EquipmentManagerment.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        private EquipmentManangermentEntities1 db = new EquipmentManangermentEntities1();
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.ListOfDropdown = db.Addresses.ToList();
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account acc)
        {
            var response = Request["g-recaptcha-reponse"];
            string secretKey = "6LcQP58jAAAAALQrid1mLHwPA9FLxfZbcBGE1S_e";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");
            ViewBag.Massage = status ? "Xác nhận thành công" : "Xác nhận thất bại";

            var tk = db.Accounts.Where(x => x.TenDangNhap == acc.TenDangNhap && x.MatKhau == acc.MatKhau).Count();
            if (tk > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public JsonResult GetAllLocation()
        {
            var data = db.Addresses.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllLocationById(int id)
        {
            var data = db.Addresses.Where(x => x.ID == id).SingleOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}