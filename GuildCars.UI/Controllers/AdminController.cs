﻿using GuildCars.Data.Factories;
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
    [Authorize(Roles="Admin")]
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

            var makeRepo = GuildCarsRepositoryFactory.GetRepository();
            var modelRepo = GuildCarsRepositoryFactory.GetRepository();

            model.Make = new SelectList(makeRepo.GetMakes(), "MakeId", "MakeName");
            model.Model = new SelectList(modelRepo.GetModels(), "ModelId", "ModelName");
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


            return View("EditVehicle");
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }

        public ActionResult EditVehicle()
        {
            var model = new VehicleAddViewModel();

            var makeRepo = GuildCarsRepositoryFactory.GetRepository();
            var modelRepo = GuildCarsRepositoryFactory.GetRepository();

            model.Make = new SelectList(makeRepo.GetMakes(), "MakeId", "MakeName");
            model.Model = new SelectList(modelRepo.GetModels(), "ModelId", "ModelName");
            model.Car = new Car();

            return View(model);
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

        public ActionResult PostUser(User user)
        {
            var roleId = user.Role;

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            GuildCarsRepositoryFactory.GetRepository().AddUser(user);

            GuildCarsRepositoryFactory.GetRepository().AddUserRole(roleId);
            //db.SaveChanges();

            var model1 = new UserEditViewModel();

            var roleRepo = GuildCarsRepositoryFactory.GetRepository();

            model1.Role = new SelectList(roleRepo.GetRoles(), "Id", "Name");
            model1.User = new User();


            return View("AddUser", model1);
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }

        [HttpGet]
        public ActionResult EditUser()
        {

            var model = new UserEditViewModel();

            var roleRepo = GuildCarsRepositoryFactory.GetRepository();

            model.Role = new SelectList(roleRepo.GetRoles(), "Id", "Name");
            model.User = new User();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditUserPost(User user)
        {
            var userId = user.Id;
            var roleId = user.Role;

            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
            }

            GuildCarsRepositoryFactory.GetRepository().EditUser(user);
            GuildCarsRepositoryFactory.GetRepository().EditUserRole(userId, roleId);
            //db.SaveChanges();

            var model1 = new UserEditViewModel();

            var roleRepo = GuildCarsRepositoryFactory.GetRepository();

            model1.Role = new SelectList(roleRepo.GetRoles(), "Id", "Name");
            model1.User = new User();

            return View("EditUser", model1);
            //return Created($"api/Dvds1/{dvd.DvdId})", dvd);
            //return null;
            //return CreatedAtRoute("DefaultApi", new { id = dvd.DvdId }, dvd);
        }

        /*
        public ActionResult AddUser()
        {
            var model = new ModelEditViewModel();

            var roleRepo = GuildCarsRepositoryFactory.GetRepository();

            model.Make = new SelectList(makeRepo.GetMakes(), "MakeId", "MakeName");
            model.Model = new Model();

            return View(model);
        }
        */
    }
}