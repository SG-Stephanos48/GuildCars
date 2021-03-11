using GuildCars.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [Authorize(Roles = "Sales, Admin")]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            //List<Car> list = new List<Car>();
            var model = GuildCarsRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        public ActionResult Purchase(int id)
        {
            //List<Car> list = new List<Car>();
            var model = GuildCarsRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }
    }
}