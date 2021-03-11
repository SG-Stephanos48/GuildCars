using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class GuildCarsRepositoryADO : IGuildCarsRepository
    {

        public void Delete(int carId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("CarDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CarId", carId);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public List<Car> GetAll()
        {
            List<Car> cars = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Car currentRow = new Car();
                        currentRow.CarId = (int)dr["CarId"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.PurchaseDate = (DateTime)dr["PurchaseDate"];
                        currentRow.CarType = dr["CarType"].ToString();
                        currentRow.BodyStyle = dr["BodyStyle"].ToString();
                        currentRow.MfgYear = dr["MfgYear"].ToString();
                        currentRow.Transmission = dr["Transmission"].ToString();
                        currentRow.Color = dr["Color"].ToString();
                        currentRow.Interior = dr["Interior"].ToString();
                        currentRow.Mileage = dr["Mileage"].ToString();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalesPrice = (decimal)dr["SalesPrice"];
                        currentRow.CarDescription = dr["CarDescription"].ToString();
                        currentRow.Feature = (bool)dr["Feature"];

                        if (dr["ImageFileName"] != DBNull.Value)
                            currentRow.ImageFileName = dr["ImageFileName"].ToString();

                        cars.Add(currentRow);
                    }
                }
            }
            return cars;
        }

        public Car GetById(int carId)
        {
            Car car = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CarId", carId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        car = new Car();

                        car.CarId = (int)dr["CarId"];
                        car.MakeName = dr["MakeName"].ToString();
                        car.ModelName = dr["ModelName"].ToString();
                        car.PurchaseDate = (DateTime)dr["PurchaseDate"];
                        car.CarType = dr["CarType"].ToString();
                        car.BodyStyle = dr["BodyStyle"].ToString();
                        car.MfgYear = dr["MfgYear"].ToString();
                        car.Transmission = dr["Transmission"].ToString();
                        car.Color = dr["Color"].ToString();
                        car.Interior = dr["Interior"].ToString();
                        car.Mileage = dr["Mileage"].ToString();
                        car.VIN = dr["VIN"].ToString();
                        car.MSRP = (decimal)dr["MSRP"];
                        car.SalesPrice = (decimal)dr["SalesPrice"];
                        car.CarDescription = dr["CarDescription"].ToString();
                        car.Feature = (bool)dr["Feature"];

                        if (dr["ImageFileName"] != DBNull.Value)
                            car.ImageFileName = dr["ImageFileName"].ToString();

                    }
                }
            }
            return car;
        }

        public List<Special> GetSpecials()
        {
            List<Special> specials = new List<Special>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special currentRow = new Special();
                        currentRow.SpecialId = (int)dr["SpecialId"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.SpecialDescription = dr["SpecialDescription"].ToString();

                        specials.Add(currentRow);
                    }
                }
            }
            return specials;
        }

        public void Insert(Car car)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CarId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeId", car.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", car.ModelId);
                cmd.Parameters.AddWithValue("@PurchaseId", car.PurchaseId);
                cmd.Parameters.AddWithValue("@CarType", car.CarType);
                cmd.Parameters.AddWithValue("@BodyStyle", car.BodyStyle);
                cmd.Parameters.AddWithValue("@MfgYear", car.MfgYear);
                cmd.Parameters.AddWithValue("@Transmission", car.Transmission);
                cmd.Parameters.AddWithValue("@Color", car.Color);
                cmd.Parameters.AddWithValue("@Interior", car.Interior);
                cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                cmd.Parameters.AddWithValue("@VIN", car.VIN);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@SalesPrice", car.SalesPrice);
                cmd.Parameters.AddWithValue("@CarDescription", car.CarDescription);
                cmd.Parameters.AddWithValue("@Feature", car.Feature);
                cmd.Parameters.AddWithValue("@ImageFileName", car.ImageFileName);

                cn.Open();

                cmd.ExecuteNonQuery();

                car.CarId = (int)param.Value;
            }
        }

        public void Update(Car car)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MakeId", car.MakeId);
                cmd.Parameters.AddWithValue("@ModelId", car.ModelId);
                cmd.Parameters.AddWithValue("@PurchaseId", car.PurchaseId);
                cmd.Parameters.AddWithValue("@CarType", car.CarType);
                cmd.Parameters.AddWithValue("@BodyStyle", car.BodyStyle);
                cmd.Parameters.AddWithValue("@MfgYear", car.MfgYear);
                cmd.Parameters.AddWithValue("@Transmission", car.Transmission);
                cmd.Parameters.AddWithValue("@Color", car.Color);
                cmd.Parameters.AddWithValue("@Interior", car.Interior);
                cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                cmd.Parameters.AddWithValue("@VIN", car.VIN);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@SalesPrice", car.SalesPrice);
                cmd.Parameters.AddWithValue("@CarDescription", car.CarDescription);
                cmd.Parameters.AddWithValue("@Feature", car.Feature);
                cmd.Parameters.AddWithValue("@ImageFileName", car.ImageFileName);

                cn.Open();

                cmd.ExecuteNonQuery();
            }

        }

        public void ContactUs(string VIN)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VINInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VIN", VIN);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void ContactInsert(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);


                cmd.Parameters.AddWithValue("@ContactName", contact.ContactName);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.Parameters.AddWithValue("@ContactMessage", contact.ContactMessage);

                /*
                cmd.Parameters.AddWithValue("@StatesId", contact.StatesId);
                cmd.Parameters.AddWithValue("@PurchaseId", contact.PurchaseId);
                cmd.Parameters.AddWithValue("@Street1", contact.Street1);
                cmd.Parameters.AddWithValue("@Street2", contact.Street2);
                cmd.Parameters.AddWithValue("@City", contact.City);
                cmd.Parameters.AddWithValue("@ZipCode", contact.ZipCode);
                */

                cn.Open();

                cmd.ExecuteNonQuery();

                contact.ContactId = (int)param.Value;
            }
        }

        public void ContactInsert1(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);


                cmd.Parameters.AddWithValue("@ContactName", contact.ContactName);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.Parameters.AddWithValue("@ContactMessage", contact.ContactMessage);

                
                cmd.Parameters.AddWithValue("@StatesId", contact.StatesId);
                cmd.Parameters.AddWithValue("@PurchaseId", contact.PurchaseId);
                cmd.Parameters.AddWithValue("@Street1", contact.Street1);
                cmd.Parameters.AddWithValue("@Street2", contact.Street2);
                cmd.Parameters.AddWithValue("@City", contact.City);
                cmd.Parameters.AddWithValue("@ZipCode", contact.ZipCode);
                

                cn.Open();

                cmd.ExecuteNonQuery();

                contact.ContactId = (int)param.Value;
            }
        }

        public IEnumerable<SearchItem> SearchNew(CarSearchParameters parameters)
        {
            List<SearchItem> cars = new List<SearchItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 c.CarId, c.MfgYear, m.MakeName, ma.ModelName, c.BodyStyle, c.CarType, c.Transmission, c.Color, c.Interior, c.Mileage, c.VIN, c.SalesPrice, c.MSRP, c.ImageFileName, c.Feature, p.PurchaseDate " +
                                "FROM Car c " +
                                    "JOIN Make m ON c.MakeId = m.MakeId " +
                                    "JOIN Model ma ON c.ModelId = ma.ModelId " +
                                    "JOIN Purchase p ON c.PurchaseId = p.PurchaseId " +
                                "WHERE 1 = 1 AND CarType = 'New' ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.MinPrice.HasValue)
                {
                    query += " AND SalesPrice >= @MinPrice";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += " AND SalesPrice <= @MaxPrice";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (!string.IsNullOrEmpty(parameters.MinMfgYear))
                {
                    query += " AND MfgYear >= @MinMfgYear";
                    cmd.Parameters.AddWithValue("@MinMfgYear", parameters.MinMfgYear + "%");
                }

                if (!string.IsNullOrEmpty(parameters.MaxMfgYear))
                {
                    query += " AND MfgYear <= @MaxMfgYear";
                    cmd.Parameters.AddWithValue("@MaxMfgYear", parameters.MaxMfgYear + "%");
                }

                if (!string.IsNullOrEmpty(parameters.MagicTerm))
                {
                    query += " AND MakeName Like @MagicTerm OR ModelName Like @MagicTerm OR MfgYear Like @MagicTerm ";
                    cmd.Parameters.AddWithValue("@MagicTerm", parameters.MagicTerm + "%");
                }

                query += " ORDER BY SalesPrice DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchItem row = new SearchItem();

                        row.CarId = (int)dr["CarId"];
                        row.MfgYear = dr["MfgYear"].ToString();
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        row.CarType = dr["CarType"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Transmission = dr["Transmission"].ToString();
                        row.Color = dr["Color"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();
                        row.Feature = (bool)dr["Feature"];

                        cars.Add(row);
                    }
                }
            }

            return cars;

        }

        public IEnumerable<SearchItem> SearchUsed(CarSearchParameters parameters)
        {
            List<SearchItem> cars = new List<SearchItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 c.CarId, c.MfgYear, m.MakeName, ma.ModelName, c.BodyStyle, c.CarType, c.Transmission, c.Color, c.Interior, c.Mileage, c.VIN, c.SalesPrice, c.MSRP, c.ImageFileName, c.Feature, p.PurchaseDate " +
                                "FROM Car c " +
                                    "JOIN Make m ON c.MakeId = m.MakeId " +
                                    "JOIN Model ma ON c.ModelId = ma.ModelId " +
                                    "JOIN Purchase p ON c.PurchaseId = p.PurchaseId " +
                                "WHERE 1 = 1 AND CarType = 'Used'";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.MinPrice.HasValue)
                {
                    query += " AND SalesPrice >= @MinPrice";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += " AND SalesPrice <= @MaxPrice";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (!string.IsNullOrEmpty(parameters.MinMfgYear))
                {
                    query += " AND MfgYear >= @MinMfgYear";
                    cmd.Parameters.AddWithValue("@MinMfgYear", parameters.MinMfgYear + "%");
                }

                if (!string.IsNullOrEmpty(parameters.MaxMfgYear))
                {
                    query += " AND MfgYear <= @MaxMfgYear";
                    cmd.Parameters.AddWithValue("@MaxMfgYear", parameters.MaxMfgYear + "%");
                }

                if (!string.IsNullOrEmpty(parameters.MagicTerm))
                {
                    query += " AND MakeName Like @MagicTerm OR ModelName Like @MagicTerm OR MfgYear Like @MagicTerm ";
                    cmd.Parameters.AddWithValue("@MagicTerm", parameters.MagicTerm + "%");
                }

                query += " ORDER BY SalesPrice DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchItem row = new SearchItem();

                        row.CarId = (int)dr["CarId"];
                        row.MfgYear = dr["MfgYear"].ToString();
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        row.CarType = dr["CarType"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Transmission = dr["Transmission"].ToString();
                        row.Color = dr["Color"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();
                        row.Feature = (bool)dr["Feature"];

                        cars.Add(row);
                    }
                }
            }

            return cars;

        }

        public IEnumerable<SearchItem> SearchSales(CarSearchParameters parameters)
        {
            List<SearchItem> cars = new List<SearchItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 c.CarId, c.MfgYear, m.MakeName, ma.ModelName, c.BodyStyle, c.CarType, c.Transmission, c.Color, c.Interior, c.Mileage, c.VIN, c.SalesPrice, c.MSRP, c.ImageFileName, c.Feature, p.PurchaseDate " +
                                "FROM Car c " +
                                    "JOIN Make m ON c.MakeId = m.MakeId " +
                                    "JOIN Model ma ON c.ModelId = ma.ModelId " +
                                    "JOIN Purchase p ON c.PurchaseId = p.PurchaseId " +
                                "WHERE 1 = 1 ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.MinPrice.HasValue)
                {
                    query += " AND SalesPrice >= @MinPrice";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += " AND SalesPrice <= @MaxPrice";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (!string.IsNullOrEmpty(parameters.MinMfgYear))
                {
                    query += " AND MfgYear >= @MinMfgYear";
                    cmd.Parameters.AddWithValue("@MinMfgYear", parameters.MinMfgYear + "%");
                }

                if (!string.IsNullOrEmpty(parameters.MaxMfgYear))
                {
                    query += " AND MfgYear <= @MaxMfgYear";
                    cmd.Parameters.AddWithValue("@MaxMfgYear", parameters.MaxMfgYear + "%");
                }

                if (!string.IsNullOrEmpty(parameters.MagicTerm))
                {
                    query += " AND MakeName Like @MagicTerm OR ModelName Like @MagicTerm OR MfgYear Like @MagicTerm ";
                    cmd.Parameters.AddWithValue("@MagicTerm", parameters.MagicTerm + "%");
                }

                query += " ORDER BY SalesPrice DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchItem row = new SearchItem();

                        row.CarId = (int)dr["CarId"];
                        row.MfgYear = dr["MfgYear"].ToString();
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        row.CarType = dr["CarType"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Transmission = dr["Transmission"].ToString();
                        row.Color = dr["Color"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();
                        row.Feature = (bool)dr["Feature"];

                        cars.Add(row);
                    }
                }
            }

            return cars;

        }

        public IEnumerable<SearchItem> SearchAdmin(CarSearchParameters parameters)
        {
            List<SearchItem> cars = new List<SearchItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 20 c.CarId, c.MfgYear, m.MakeName, ma.ModelName, c.BodyStyle, c.CarType, c.Transmission, c.Color, c.Interior, c.Mileage, c.VIN, c.SalesPrice, c.MSRP, c.ImageFileName, c.Feature, p.PurchaseDate " +
                                "FROM Car c" +
                                    "JOIN Make m ON c.MakeId = m.MakeId " +
                                    "JOIN Model ma ON c.ModelId = ma.ModelId " +
                                    "JOIN Purchase p ON c.PurchaseId = p.PurchaseId " +
                                "WHERE 1 = 1 AND p.PurchaseDate IS NULL";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.MinPrice.HasValue)
                {
                    query += " AND SalesPrice >= @MinPrice";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += " AND SalesPrice <= @MaxPrice";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (!string.IsNullOrEmpty(parameters.MinMfgYear))
                {
                    query += " AND MfgYear >= @MinMfgYear";
                    cmd.Parameters.AddWithValue("@MinMfgYear", parameters.MinMfgYear + "%");
                }

                if (!string.IsNullOrEmpty(parameters.MaxMfgYear))
                {
                    query += " AND MfgYear <= @MaxMfgYear";
                    cmd.Parameters.AddWithValue("@MaxMfgYear", parameters.MaxMfgYear + "%");
                }

                if (!string.IsNullOrEmpty(parameters.MagicTerm))
                {
                    query += " AND MakeName Like @MagicTerm OR ModelName Like @MagicTerm OR MfgYear Like @MagicTerm ";
                    cmd.Parameters.AddWithValue("@MagicTerm", parameters.MagicTerm + "%");
                }

                query += " ORDER BY SalesPrice DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchItem row = new SearchItem();

                        row.CarId = (int)dr["CarId"];
                        row.MfgYear = dr["MfgYear"].ToString();
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        row.CarType = dr["CarType"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.Transmission = dr["Transmission"].ToString();
                        row.Color = dr["Color"].ToString();
                        row.Interior = dr["Interior"].ToString();
                        row.Mileage = dr["Mileage"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        row.MSRP = (decimal)dr["MSRP"];
                        if (dr["ImageFileName"] != DBNull.Value)
                            row.ImageFileName = dr["ImageFileName"].ToString();
                        row.Feature = (bool)dr["Feature"];

                        cars.Add(row);
                    }
                }
            }

            return cars;

        }

        public void AddSpecial(Special special)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SpecialId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", special.Title);
                cmd.Parameters.AddWithValue("@SpecialDescription", special.SpecialDescription);

                cn.Open();

                cmd.ExecuteNonQuery();

                special.SpecialId = (int)param.Value;
            }
        }

        public void AddMake(Make make, string currentUser)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MakeId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cmd.Parameters.AddWithValue("@DateCreated", make.DateCreated = DateTime.Today);
                cmd.Parameters.AddWithValue("@UserId", make.UserId = currentUser);
                
                cn.Open();

                cmd.ExecuteNonQuery();

                make.MakeId = (int)param.Value;
            }
        }

        public void AddModel(Model model, string currentUser)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeId", model.MakeId);
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@DateCreated", model.DateCreated = DateTime.Today);
                cmd.Parameters.AddWithValue("@UserId", model.UserId = currentUser);

                cn.Open();

                cmd.ExecuteNonQuery();

                model.ModelId = (int)param.Value;
            }
        }

        public List<Make> GetMakes()
        {
            List<Make> makes = new List<Make>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.DateCreated = (DateTime)dr["DateCreated"];

                        makes.Add(currentRow);
                    }
                }
            }
            return makes;
        }

        public List<Model> GetModels()
        {
            List<Model> models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.DateCreated = (DateTime)dr["DateCreated"];

                        models.Add(currentRow);
                    }
                }
            }
            return models;
        }

        public List<VehicleReport> GetNew()
        {
            List<VehicleReport> report = new List<VehicleReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetNewCarReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleReport currentRow = new VehicleReport();
                        currentRow.MfgYear = dr["MfgYear"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Count = (int)dr["Count"];
                        currentRow.StockValue = (decimal)dr["StockValue"];

                        report.Add(currentRow);
                    }
                }
            }
            return report;
        }

        public List<VehicleReport> GetUsed()
        {
            List<VehicleReport> report = new List<VehicleReport>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetUsedCarReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleReport currentRow = new VehicleReport();
                        currentRow.MfgYear = dr["MfgYear"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.Count = (int)dr["Count"];
                        currentRow.StockValue = (decimal)dr["StockValue"];

                        report.Add(currentRow);
                    }
                }
            }
            return report;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetUsers", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        User currentRow = new User();
                        currentRow.Id = dr["Id"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.Role = dr["Name"].ToString();

                        users.Add(currentRow);
                    }
                }
            }
            return users;
        }

        public void AddUser(User user)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UserInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@PasswordConfirmed", user.PasswordConfirmed);

                cn.Open();

                cmd.ExecuteNonQuery();

                user.Id = param.Value.ToString();
            }
        }

        public void AddUserRole(string roleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UserRoleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@Id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                //cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@RoleId", roleId);

                cn.Open();

                cmd.ExecuteNonQuery();

                //userId = param.Value.ToString();
            }
        }

        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetRoles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Role currentRow = new Role();
                        currentRow.Id = dr["Id"].ToString();
                        currentRow.Name = dr["Name"].ToString();

                        roles.Add(currentRow);
                    }
                }
            }
            return roles;
        }

        public List<UserRole> GetUserRoles()
        {
            List<UserRole> userroles = new List<UserRole>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetUserRoles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        UserRole currentRow = new UserRole();
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.RoleId = (int)dr["RoleId"];

                        userroles.Add(currentRow);
                    }
                }
            }
            return userroles;
        }

        public void EditUser(User user)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EditUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                cn.Open();

                cmd.ExecuteNonQuery();
            }

        }

        public void EditUserRole(string userId, string roleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EditUserRole", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@RoleId", roleId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }

        }

    }
}
