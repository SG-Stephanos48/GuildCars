﻿using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IGuildCarsRepository
    {

        List<Car> GetAll();
        Car GetById(int carId);
        void Insert(Car car);
        void Update(Car car);
        void Delete(int carId);
        IEnumerable<SearchItem> SearchNew(CarSearchParameters parameters);
        IEnumerable<SearchItem> SearchUsed(CarSearchParameters parameters);
        IEnumerable<SearchItem> SearchSales(CarSearchParameters parameters);
        void ContactUs(string VIN);
        void ContactInsert(Contact contact);
        List<Special> GetSpecials();
        void AddSpecial(Special special);
        List<Make> GetMakes();
        void AddMake(Make make, string currentUser);
        List<Model> GetModels();
        void AddModel(Model model, string currentUser);
        List<VehicleReport> GetNew();
        List<VehicleReport> GetUsed();
        List<User> GetUsers();
        List<Role> GetRoles();
        List<UserRole> GetUserRoles();
        void AddUser(User user);
        void AddUserRole(string roleId);
        void EditUser(User user);
        void EditUserRole(string userId, string roleId);

    }
}