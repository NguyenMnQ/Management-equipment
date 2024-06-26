using EquipmentManagerment.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipmentManagerment.Controllers
{
    public class HomeController : Controller
    {
        private EquipmentManangermentEntities1 db = new EquipmentManangermentEntities1();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}