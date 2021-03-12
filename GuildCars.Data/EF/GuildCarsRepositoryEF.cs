using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.EF
{
    public class GuildCarsRepositoryEF : IGuildCarsRepository
    {

        private GuildCarEntities db = new GuildCarEntities();

        public void AddMake(Make make)
        {
            throw new NotImplementedException();
        }

        public void AddMake(Make make, string currentUser)
        {
            throw new NotImplementedException();
        }

        public void AddModel(Model model)
        {
            throw new NotImplementedException();
        }

        public void AddModel(Model model, string currentUser)
        {
            throw new NotImplementedException();
        }

        public void AddPurchase(Purchase purchase, string currentUser)
        {
            throw new NotImplementedException();
        }

        public void AddSpecial(Special special)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void AddUserRole(string roleId)
        {
            throw new NotImplementedException();
        }

        public void ContactInsert(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void ContactInsert1(Contact contact, int purchaseId)
        {
            throw new NotImplementedException();
        }

        public void ContactUs(string VIN)
        {
            throw new NotImplementedException();
        }

        public void Delete(int carId)
        {
            var car = db.Cars.FirstOrDefault(c => c.CarId == carId);
            db.Cars.Remove(car);
            db.SaveChanges();
        }

        public void EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public void EditUserRole(string userId, string roleId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            var cars = db.Cars.ToList();
            return cars;
        }

        public List<BodyStyle> GetBodyStyles()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int carId)
        {
            var car = db.Cars.FirstOrDefault(c => c.CarId == carId);
            return car;
        }

        public List<CarType> GetCarTypes()
        {
            throw new NotImplementedException();
        }

        public List<Color> GetColors()
        {
            throw new NotImplementedException();
        }

        public List<Interior> GetInteriors()
        {
            throw new NotImplementedException();
        }

        public List<Make> GetMakes()
        {
            throw new NotImplementedException();
        }

        public List<Model> GetModels()
        {
            throw new NotImplementedException();
        }

        public List<VehicleReport> GetNew()
        {
            throw new NotImplementedException();
        }

        public List<Purchase> GetPurchaseIds()
        {
            throw new NotImplementedException();
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            throw new NotImplementedException();
        }

        public List<Role> GetRoles()
        {
            throw new NotImplementedException();
        }

        public List<Special> GetSpecials()
        {
            throw new NotImplementedException();
        }

        public List<State> GetStates()
        {
            throw new NotImplementedException();
        }

        public List<Transmission> GetTransmissions()
        {
            throw new NotImplementedException();
        }

        public List<VehicleReport> GetUsed()
        {
            throw new NotImplementedException();
        }

        public List<UserRole> GetUserRoles()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void Insert(Car car)
        {
            car.CarId = db.Cars.Max(x => x.CarId) + 1;
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public IEnumerable<SalesReport> SalesReport(SalesReportParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchItem> Search(CarSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchItem> SearchNew(CarSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchItem> SearchSales(CarSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchItem> SearchUsed(CarSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carnew = new Car();

            carnew = db.Cars.FirstOrDefault(c => c.CarId == car.CarId);

            carnew.CarId = car.CarId;
            carnew.MakeId = car.MakeId;
            carnew.ModelId = car.ModelId;
            /*carnew.CarType = car.CarType;
            carnew.BodyStyle = car.BodyStyle;
            carnew.MfgYear = car.MfgYear;
            carnew.Transmission = car.Transmission;
            carnew.Color = car.Color;
            carnew.Interior = car.Interior;*/
            carnew.Mileage = car.Mileage;
            carnew.VIN = car.VIN;
            carnew.MSRP = car.MSRP;
            carnew.SalesPrice = car.SalesPrice;
            carnew.CarDescription = car.CarDescription;
            carnew.ImageFileName = car.ImageFileName;
            carnew.PurchaseId = car.PurchaseId;
            carnew.Feature = car.Feature;

            db.SaveChanges();
        }

        public void UpdatePurchaseStatus(Car car)
        {
            throw new NotImplementedException();
        }

        public void UpdatePurchaseStatus(Car car, int purchaseId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePurchaseStatus(int carId, int purchaseId)
        {
            throw new NotImplementedException();
        }
    }
}
