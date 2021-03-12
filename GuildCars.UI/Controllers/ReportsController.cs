using GuildCars.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            return View();
        }

        public ActionResult _GetNew()
        {
            var model = GuildCarsRepositoryFactory.GetRepository().GetNew();
            return View("_List", model);
        }

        public ActionResult _GetUsed()
        {
            var model = GuildCarsRepositoryFactory.GetRepository().GetUsed();
            return View("_List", model);
        }

        public ActionResult Sales()
        {
            //var userName = "choose"; 
            return View();
        }
    }
}