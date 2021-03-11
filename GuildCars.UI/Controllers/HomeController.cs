using GuildCars.Data.EF;
using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        private GuildCarEntities db = new GuildCarEntities();

        public ActionResult Index()
        {
            //List<Car> list = new List<Car>();
            var model = GuildCarsRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        public ActionResult Specials()
        {
            //List<Car> list = new List<Car>();
            var model = GuildCarsRepositoryFactory.GetRepository().GetSpecials();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult ContactInsert(Contact contact)
        {

            var repo = GuildCarsRepositoryFactory.GetRepository();
            repo.ContactInsert(contact);

            return View("Contact");
            //return RedirectToAction("Edit", new { id = model.Listing.ListingId });

        }

        [HttpPost]
        public ActionResult AddSpecial(Special special)
        {

            var repo = GuildCarsRepositoryFactory.GetRepository();
            repo.AddSpecial(special);

            return View("Index");
            //return RedirectToAction("Edit", new { id = model.Listing.ListingId });

        }
    }
}