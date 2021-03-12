using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
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
            var cardetails = GuildCarsRepositoryFactory.GetRepository().GetById(id);

            ViewBag.carid = cardetails.CarId;

            var model = new PurchaseAddViewModel();

            var Repo = GuildCarsRepositoryFactory.GetRepository();

            model.States = new SelectList(Repo.GetStates(), "StateId", "StateName");
            model.PurchaseTypes = new SelectList(Repo.GetPurchaseTypes(), "PurchaseTypeId", "PurchaseTypeName");
            model.Car = cardetails;
            model.Purchase = new Purchase();
            model.Contact = new Contact();

            return View(model);
        }

        public ActionResult PostPurchase(PurchaseAddViewModel pviewmodel)
        {

            var carId = pviewmodel.Car.CarId;

            //var carId = 4;

            var purchase = pviewmodel.Purchase;

            var contact = pviewmodel.Contact;

            var currentUser = User.Identity.GetUserName();

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            List<Purchase> ids = new List<Purchase>(); 

            ids = GuildCarsRepositoryFactory.GetRepository().GetPurchaseIds();

            int purchaseId = ids.Max(x => x.PurchaseId) + 1;

            GuildCarsRepositoryFactory.GetRepository().AddPurchase(purchase, currentUser);
            GuildCarsRepositoryFactory.GetRepository().ContactInsert1(contact, purchaseId);
            GuildCarsRepositoryFactory.GetRepository().UpdatePurchaseStatus(carId, purchaseId);
            //db.SaveChanges();

            var model = GuildCarsRepositoryFactory.GetRepository().GetAll();

            return View("Index", model);
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }


    }
}