using GuildCars.Data.EF;
using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InventoryController : Controller
    {
        private GuildCarEntities db = new GuildCarEntities();
        // GET: Inventory
        public ActionResult Index()
        {
            List<Car> list = new List<Car>();
            list = GuildCarsRepositoryFactory.GetRepository().GetAll();
            return View(list);
        }

        public ActionResult New()
        {
            List<Car> list = new List<Car>();
            list = GuildCarsRepositoryFactory.GetRepository().GetAll();
            return View(list);
        }

        public ActionResult Used()
        {
            List<Car> list = new List<Car>();
            list = GuildCarsRepositoryFactory.GetRepository().GetAll();
            return View(list);
        }

        public ActionResult GetCars()
        {
            List<Car> list = new List<Car>();
            list = GuildCarsRepositoryFactory.GetRepository().GetAll();
            return View(list);
            //return db.Dvds;
        }

        // GET: api/Dvds1/5
        public ActionResult GetById(int carId)
        {
            Car car = GuildCarsRepositoryFactory.GetRepository().GetById(carId);

            return View(car);
        }

        // GET: api/Dvds1/5
        public ActionResult Details(int CarId)
        {
            Car car = GuildCarsRepositoryFactory.GetRepository().GetById(CarId);
            
            if (car.PurchaseDate != null)
            {
                ViewBag.purchased = car.PurchaseDate;
            }
            else
            {
                ViewBag.purchaseId = null;
            }

            return View(car);
        }

        // PUT: api/Dvds1/5
        public ActionResult PutCar(Car car)
        {

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            Car car1 = GuildCarsRepositoryFactory.GetRepository().GetById(car.CarId);

            if (car1 == null)
            {
                //return NotFound();
            }

            car1.MakeName = car.MakeName;
            car1.ModelName = car.ModelName;
            car1.CarTypeName = car.CarTypeName;
            car1.BodyStyleName = car.BodyStyleName;
            car1.MfgYear = car.MfgYear;
            car1.TransName = car.TransName;
            car1.ColorName = car.ColorName;
            car1.InteriorName = car.InteriorName;
            car1.Mileage = car.Mileage;
            car1.VIN = car.VIN;
            car.MSRP = car.MSRP;
            car1.SalesPrice = car.SalesPrice;
            car1.CarDescription = car.CarDescription;
            car1.ImageFileName = car.ImageFileName;
            car1.PurchaseId = car.PurchaseId;
            car1.Feature = car.Feature;

            GuildCarsRepositoryFactory.GetRepository().Update(car1);

            return View(car1);

        }

        // POST: api/Dvds1
        public ActionResult PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            GuildCarsRepositoryFactory.GetRepository().Insert(car);
            //db.SaveChanges();

            return View();
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }

        // DELETE: api/Dvds1/5
        public ActionResult DeleteCar(int carId)
        {
            Car car = GuildCarsRepositoryFactory.GetRepository().GetById(carId);

            if (car == null)
            {

                //return NotFound();

            }

            GuildCarsRepositoryFactory.GetRepository().Delete(carId);
            return View();
            /*Dvd dvd = db.Dvds.Find(id);
            if (dvd == null)
            {
                return NotFound();
            }

            db.Dvds.Remove(dvd);
            db.SaveChanges();

            return Ok(dvd);
            */
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Cars.Count(e => e.CarId == id) > 0;
        }
    }
}