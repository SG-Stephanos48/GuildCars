using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Mock
{
    public class GuildCarsRepositoryMock : IGuildCarsRepository
    {

        public static List<Car> _cars = new List<Car>
        {
            new Car
            {
                CarId = 1,
                MakeId = 1,
                ModelId = 1,
                PurchaseId = 1,
                ContactId = 1,
                CarTypeId = 1,
                BodyStyleId = 2,
                MfgYear = "2021",
                TransId = 2,
                ColorId = 3,
                InteriorId = 2,
                Mileage = "150",
                VIN ="F2020600000343",
                MSRP = 23950,
                SalesPrice = 21000,
                CarDescription = "New car w/ great personality!",
                ImageFileName = "car.jpg",
                Feature = true
            },
            new Car
            {
                CarId = 2,
                MakeId = 2,
                ModelId = 2,
                PurchaseId = 2,
                ContactId = 2,
                CarTypeId = 1,
                BodyStyleId = 1,
                MfgYear = "2021",
                TransId = 1,
                ColorId = 3,
                InteriorId = 2,
                Mileage = "76",
                VIN ="VW20210000T2010",
                MSRP = 27500,
                SalesPrice = 24000,
                CarDescription = "New car that speaks German",
                ImageFileName = "car.jpg",
                Feature = false
            },
            new Car
            {
                CarId = 3,
                MakeId = 3,
                ModelId = 3,
                PurchaseId = 3,
                ContactId = 3,
                CarTypeId = 1,
                BodyStyleId = 1,
                MfgYear = "2018",
                TransId = 1,
                ColorId = 3,
                InteriorId = 2,
                Mileage = "14500",
                VIN ="DS20210000T2018",
                MSRP = 32500,
                SalesPrice = 27500,
                CarDescription = "Lightly used sprinter van",
                ImageFileName = "car.jpg",
                Feature = true
            }

        };

        public static List<Make> _makes = new List<Make>
        {
            new Make
            {
                MakeId = 1,
                UserId = "stephen.english@me.com",
                MakeName = "Ford",
                DateCreated = new DateTime(2018, 6, 1, 7, 47, 0)
            },
            new Make
            {
                MakeId = 2,
                UserId = "stephen.english@me.com",
                MakeName = "Toyota",
                DateCreated = new DateTime(2018, 6, 1, 7, 48, 0)
            },
            new Make
            {
                MakeId = 3,
                UserId = "stephen.english@me.com",
                MakeName = "Dodge",
                DateCreated = new DateTime(2018, 6, 1, 7, 49, 0)
            }

        };

        public static List<Contact> _contacts = new List<Contact>
        {
            new Contact
            {

                ContactId = 1,
                StatesId = "AL",
                PurchaseId = 1,
                ContactName = "Bruno Mars",
                Email = "bruno@gmail.com",
                Phone = "678-888-1000",
                ContactMessage ="I really want a porsche",
                Street1 = "3801 Godfrey Ave NE",
                Street2 = "",
                City = "Ft Payne",
                ZipCode ="35967"

            },
            new Contact
            {
                ContactId = 2,
                StatesId = "TX",
                PurchaseId = 2,
                ContactName = "Johnny Sauce",
                Email = "jethro@gmail.com",
                Phone = "432-888-1000",
                ContactMessage ="I really want a tesla baby",
                Street1 = "123 Royal Highway",
                Street2 = "",
                City = "Dallas",
                ZipCode ="76040"
            }

        };

        public static List<Model> _models = new List<Model>
        {
            new Model
            {
                ModelId = 1,
                UserId = "stephen.english@me.com",
                MakeId = 1,
                ModelName = "Explorer",
                DateCreated = new DateTime(2018, 6, 1, 7, 50, 0)
            },
            new Model
            {
                ModelId = 2,
                UserId = "stephen.english@me.com",
                MakeId = 2,
                ModelName = "Camry",
                DateCreated = new DateTime(2018, 6, 1, 7, 51, 0)
            },
            new Model
            {
                ModelId = 3,
                UserId = "stephen.english@me.com",
                MakeId = 3,
                ModelName = "Sprinter",
                DateCreated = new DateTime(2018, 6, 1, 7, 52, 0)
            }

        };

        public static List<Special> _specials = new List<Special>
        {
            new Special
            {
                SpecialId = 1,
                Title = "2018 Dodge Sprinter",
                SpecialDescription = "Low miles!  Still a lot to give. Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit " +
                "in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, " +
                "sunt in culpa qui officia deserunt mollit anim id est laborum."
            },
            new Special
            {
                SpecialId = 2,
                Title = "2021 Toyota Camry",
                SpecialDescription = "Brand New!  Beautiful new body style. Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit " +
                "in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, " +
                "sunt in culpa qui officia deserunt mollit anim id est laborum."
            }

        };

        public static List<State> _states = new List<State>
        {
            new State
            {
                StateId = "OH",
                StateName = "Ohio"
            },
            new State
            {
                StateId = "GA",
                StateName = "Georgia"
            },
            new State
            {
                StateId = "TX",
                StateName = "Texas"
            },
            new State
            {
                StateId = "AL",
                StateName = "Alabama"
            },

        };

        public static List<PurchaseType> _purchaseTypes = new List<PurchaseType>
        {
            new PurchaseType
            {
                PurchaseTypeId = 1,
                PurchaseTypeName = "Bank Finance"
            },
            new PurchaseType
            {
                PurchaseTypeId = 2,
                PurchaseTypeName = "Cash"
            },
            new PurchaseType
            {
                PurchaseTypeId = 3,
                PurchaseTypeName = "Dealer Finance"
            }

        };

        public void Delete(int carId)
        {
            _cars.RemoveAll(m => m.CarId == carId);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Special> GetSpecials()
        {
            return _specials;
        }

        public List<Make> GetMakes()
        {
            return _makes;
        }

        public List<Model> GetModels()
        {
            return _models;
        }

        public Car GetById(int carId)
        {
            return _cars.FirstOrDefault(m => m.CarId == carId);
        }

        /*
        public List<Car> GetDirectorSearch(string searchItem)
        {
            return _cars.Where<Car>(c => c.Director == searchItem).ToList();
        }
        */

        public void Insert(Car car)
        {
            car.CarId = _cars.Max(x => x.CarId) + 1;
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            var found = _cars.FirstOrDefault(m => m.CarId == car.CarId);

            if (found != null)
                found = car;
        }
        /*
        public IEnumerable<SearchItem> Search(CarSearchParameters parameters)
        {
            var newcars = _cars.Where<Car>(m => m.CarType == "New").ToList();

            if (parameters.MinPrice.HasValue)
            {
                query += "AND Rate >= @MinRate";
                cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
            }
        }
        */
        public void ContactUs(string VIN)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchItem> Search(CarSearchParameters parameters)
        {

            throw new NotImplementedException();
            /*
            List<SearchItem> cars = new List<SearchItem>();

            if (parameters.MagicTerm != null)
            {
                
            }

            //cars = _cars.Where(m => m.MfgYear == parameters.MagicTerm)
            */
        }

        public void ContactInsert(Contact contact)
        {
            contact.ContactId = _contacts.Max(x => x.ContactId) + 1;
            _contacts.Add(contact);
        }

        public void AddSpecial(Special special)
        {
            special.SpecialId = _specials.Max(x => x.SpecialId) + 1;
            _specials.Add(special);
        }

        public void AddMake(Make make)
        { 
            make.MakeId = _makes.Max(x => x.MakeId) + 1;
            make.DateCreated = DateTime.Today;
            make.UserId = "";
            make.MakeName = make.MakeName; 

            _makes.Add(make);
        }

        public void AddModel(Model model)
        {
            model.ModelId = _models.Max(x => x.ModelId) + 1;
            model.DateCreated = DateTime.Today;
            model.UserId = "";
            model.MakeId = model.MakeId;
            model.ModelName = model.ModelName;

            _models.Add(model);
        }

        public IEnumerable<SearchItem> SearchNew(CarSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchItem> SearchUsed(CarSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SearchItem> SearchSales(CarSearchParameters parameters)
        {
            throw new NotImplementedException();
        }

        public List<VehicleReport> GetNew()
        {
            throw new NotImplementedException();
        }

        public List<VehicleReport> GetUsed()
        {
            throw new NotImplementedException();
        }

        public void AddMake(Make make, string currentUser)
        {
            throw new NotImplementedException();
        }

        public void AddModel(Model model, string currentUser)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public List<Role> GetRoles()
        {
            throw new NotImplementedException();
        }

        public List<UserRole> GetUserRoles()
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

        public void EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public void EditUserRole(string userId, string roleId)
        {
            throw new NotImplementedException();
        }

        public List<State> GetStates()
        {
            throw new NotImplementedException();
        }

        public List<PurchaseType> GetPurchaseTypes()
        {
            throw new NotImplementedException();
        }

        public void AddPurchase(Purchase purchase, string currentUser)
        {
            throw new NotImplementedException();
        }

        public void UpdatePurchaseStatus(Car car)
        {
            throw new NotImplementedException();
        }

        public void ContactInsert1(Contact contact, int purchaseId)
        {
            throw new NotImplementedException();
        }

        public List<Purchase> GetPurchaseIds()
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

        public List<Interior> GetInteriors()
        {
            throw new NotImplementedException();
        }

        public List<Color> GetColors()
        {
            throw new NotImplementedException();
        }

        public List<BodyStyle> GetBodyStyles()
        {
            throw new NotImplementedException();
        }

        public List<Transmission> GetTransmissions()
        {
            throw new NotImplementedException();
        }

        public List<CarType> GetCarTypes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesReport> SalesReport(SalesReportParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void AddUserRole(string roleId, string userId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string firstName)
        {
            throw new NotImplementedException();
        }

        public void AddUser(AddUser addUser)
        {
            throw new NotImplementedException();
        }
    }
}
