using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
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
    //[Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Vehicles()
        {
            //List<Car> list = new List<Car>();
            var model = GuildCarsRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        public ActionResult AddSpecials()
        {
            return View();
        }

        public ActionResult Hidden()
        {
            return View();
        }

        public ActionResult _GetSpecialList()
        {
            List<Special> list = new List<Special>();
            list = GuildCarsRepositoryFactory.GetRepository().GetSpecials();
            return View("_SpecialList", list);
        }

        [HttpPost]
        public ActionResult PostSpecial(Special special)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            GuildCarsRepositoryFactory.GetRepository().AddSpecial(special);
            //db.SaveChanges();

            return View("AddSpecials");
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }

        public ActionResult AddVehicle()
        {
            var model = new VehicleAddViewModel();

            var Repo = GuildCarsRepositoryFactory.GetRepository();

            model.Make = new SelectList(Repo.GetMakes(), "MakeId", "MakeName");
            model.Model = new SelectList(Repo.GetModels(), "ModelId", "ModelName");
            model.Interior = new SelectList(Repo.GetInteriors(), "Id", "InteriorName");
            model.Transmission = new SelectList(Repo.GetTransmissions(), "Id", "TransName");
            model.Color = new SelectList(Repo.GetColors(), "Id", "ColorName");
            model.BodyStyle = new SelectList(Repo.GetBodyStyles(), "Id", "BodyStyleName");
            model.CarType = new SelectList(Repo.GetCarTypes(), "Id", "CarTypeName");
            model.States = new SelectList(Repo.GetStates(), "StatesId", "StatesName");

            model.Car = new Car();

            return View(model);
        }

        public ActionResult PostVehicle(Car car)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            GuildCarsRepositoryFactory.GetRepository().Insert(car);
            //db.SaveChanges();

            var model = new VehicleAddViewModel();

            var Repo = GuildCarsRepositoryFactory.GetRepository();

            model.Make = new SelectList(Repo.GetMakes(), "MakeId", "MakeName");
            model.Model = new SelectList(Repo.GetModels(), "ModelId", "ModelName");
            model.Interior = new SelectList(Repo.GetInteriors(), "Id", "InteriorName");
            model.Transmission = new SelectList(Repo.GetTransmissions(), "Id", "TransName");
            model.Color = new SelectList(Repo.GetColors(), "Id", "ColorName");
            model.BodyStyle = new SelectList(Repo.GetBodyStyles(), "Id", "BodyStyleName");
            model.CarType = new SelectList(Repo.GetCarTypes(), "Id", "CarTypeName");
            model.States = new SelectList(Repo.GetStates(), "StatesId", "StatesName");

            model.Car = new Car();

            List<Car> pass = new List<Car>();

            pass = Repo.GetAll();

            return View("Vehicles", pass);
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }

        public ActionResult EditVehicle(int carId)
        {

            var Repo = GuildCarsRepositoryFactory.GetRepository();

            var car = Repo.GetById(carId);

            var model = new VehicleAddViewModel();
            
            model.Car = car;
            model.Make = new SelectList(Repo.GetMakes(), "MakeId", "MakeName");
            model.Model = new SelectList(Repo.GetModels(), "ModelId", "ModelName");
            model.Interior = new SelectList(Repo.GetInteriors(), "Id", "InteriorName");
            model.Transmission = new SelectList(Repo.GetTransmissions(), "Id", "TransName");
            model.Color = new SelectList(Repo.GetColors(), "Id", "ColorName");
            model.BodyStyle = new SelectList(Repo.GetBodyStyles(), "Id", "BodyStyleName");
            model.CarType = new SelectList(Repo.GetCarTypes(), "Id", "CarTypeName");
            model.States = new SelectList(Repo.GetStates(), "StatesId", "StatesName");

            return View(model);
        }


        public ActionResult UpdateCar(Car car)
        {

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            GuildCarsRepositoryFactory.GetRepository().Update(car);

            var model = new VehicleAddViewModel();

            var Repo = GuildCarsRepositoryFactory.GetRepository();

            List<Car> cars = new List<Car>();

            cars = Repo.GetAll();

            model.Make = new SelectList(Repo.GetMakes(), "MakeId", "MakeName");
            model.Model = new SelectList(Repo.GetModels(), "ModelId", "ModelName");
            model.Interior = new SelectList(Repo.GetInteriors(), "Id", "InteriorName");
            model.Transmission = new SelectList(Repo.GetTransmissions(), "Id", "TransName");
            model.Color = new SelectList(Repo.GetColors(), "Id", "ColorName");
            model.BodyStyle = new SelectList(Repo.GetBodyStyles(), "Id", "BodyStyleName");
            model.CarType = new SelectList(Repo.GetCarTypes(), "Id", "CarTypeName");
            model.States = new SelectList(Repo.GetStates(), "StatesId", "StatesName");

            return View("Vehicles", cars);

        }

        public ActionResult AddMake()
        {
            return View();
        }

        public ActionResult PostMake(Make make)
        {
            var currentUser = User.Identity.GetUserName();

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            GuildCarsRepositoryFactory.GetRepository().AddMake(make, currentUser);
            //db.SaveChanges();

            return View("AddMake");
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }

        public ActionResult _GetMakes()
        {
            var model = GuildCarsRepositoryFactory.GetRepository().GetMakes();
            return View("_MakeList", model);
        }

        public ActionResult AddModel()
        {
            var model = new ModelEditViewModel();

            var makeRepo = GuildCarsRepositoryFactory.GetRepository();

            model.Make = new SelectList(makeRepo.GetMakes(), "MakeId", "MakeName");
            model.Model = new Model();

            return View(model);
        }

        public ActionResult PostModel(Model model)
        {
            var currentUser = User.Identity.GetUserName();

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            GuildCarsRepositoryFactory.GetRepository().AddModel(model, currentUser);
            //db.SaveChanges();

            var model1 = new ModelEditViewModel();

            var makeRepo = GuildCarsRepositoryFactory.GetRepository();

            model1.Make = new SelectList(makeRepo.GetMakes(), "MakeId", "MakeName");
            model1.Model = new Model();

            return View("AddModel", model1);
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }

        public ActionResult _GetModels()
        {
            var model = GuildCarsRepositoryFactory.GetRepository().GetModels();
            return View("_ModelList", model);
        }

        public ActionResult Users()
        {
            var model = GuildCarsRepositoryFactory.GetRepository().GetUsers();
            return View("Users", model);
        }

        public ActionResult AddUser()
        {

            var model = new UserEditViewModel();

            var roleRepo = GuildCarsRepositoryFactory.GetRepository();

            model.Role = new SelectList(roleRepo.GetRoles(), "Id", "Name");
            model.User = new User();

            return View(model);

        }

        public ActionResult PostUser(UserEditViewModel uviewModel)
        {
            //var roleName = uviewModel.User.RoleName;

            var user = uviewModel.User;

            string id = uviewModel.User.Id;

            Guid guidid = Guid.NewGuid();

            AddUser addUser = new AddUser();

            addUser.Id = guidid.ToString();
            addUser.FirstName = user.FirstName;
            addUser.LastName = user.LastName;
            addUser.Email = user.Email;
            addUser.EmailConfirmed = 1;
            addUser.AccessFailedCount = 1;
            addUser.LockOutEnabled = 1;
            addUser.PhoneNumberConfirmed = 1;
            addUser.TwoFactorEnabled = 1;
            addUser.UserName = "tirpitz48";

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            GuildCarsRepositoryFactory.GetRepository().AddUser(addUser);

            var userNew = GuildCarsRepositoryFactory.GetRepository().GetUser(id);

            var userId = userNew.Id;
            var roleId = userNew.RoleId;

            GuildCarsRepositoryFactory.GetRepository().AddUserRole(roleId, userId);
            //db.SaveChanges();

            var model = GuildCarsRepositoryFactory.GetRepository().GetUsers();
            return View("Users", model);
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var model = new UserEditViewModel();

            var Repo = GuildCarsRepositoryFactory.GetRepository();

            var user = Repo.GetUser(id);

            model.User = user;

            var roleRepo = GuildCarsRepositoryFactory.GetRepository();

            model.Role = new SelectList(roleRepo.GetRoles(), "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public ActionResult EditUserPost(User user)
        {
            var id = user.Id;
            var roleId = user.RoleId;

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            GuildCarsRepositoryFactory.GetRepository().EditUser(user);

            var userNew = GuildCarsRepositoryFactory.GetRepository().GetUser(id);

            var UserIdNew = userNew.Id;
            var RoleIdOld = userNew.RoleId;

            if (roleId != RoleIdOld)
            {
                GuildCarsRepositoryFactory.GetRepository().EditUserRole(UserIdNew, roleId);
            }

            //db.SaveChanges();

            var model = GuildCarsRepositoryFactory.GetRepository().GetUsers();
            return View("Users", model);
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }

    }
}