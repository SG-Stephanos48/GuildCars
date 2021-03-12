using GuildCars.Models.Queries;
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
        IEnumerable<SalesReport> SalesReport(SalesReportParameters parameters);
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
        void AddUser(AddUser addUser);
        void AddUserRole(string roleId, string userId);
        void EditUser(User user);
        void EditUserRole(string UserIdNew, string roleId);
        List<State> GetStates();
        List<PurchaseType> GetPurchaseTypes();
        void AddPurchase(Purchase purchase, string currentUser);
        void UpdatePurchaseStatus(int carId, int purchaseId);
        void ContactInsert1(Contact contact, int purchaseId);
        List<Purchase> GetPurchaseIds();
        List<Interior> GetInteriors();
        List<Color> GetColors();
        List<BodyStyle> GetBodyStyles();
        List<Transmission> GetTransmissions();
        List<CarType> GetCarTypes();
        User GetUser(string id);

    }
}
