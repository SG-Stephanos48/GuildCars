using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Car
    {

        public int CarId { get; set; }
        public string MakeName { get; set; }
        public int MakeId { get; set; }
        public string ModelName { get; set; }
        public int ModelId { get; set; }
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ContactId { get; set; }
        public int CarTypeId { get; set; }
        public string CarTypeName { get; set; }
        public int BodyStyleId { get; set; }
        public string BodyStyleName { get; set; }
        public string MfgYear { get; set; }
        public int TransId { get; set; }
        public int ColorId { get; set; }
        public int InteriorId { get; set; }
        public string TransName { get; set; }
        public string ColorName { get; set; }
        public string InteriorName { get; set; }
        public string Mileage { get; set; }
        public string VIN { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalesPrice { get; set; }
        public string CarDescription { get; set; }
        public string ImageFileName { get; set; }
        public bool Feature { get; set; }

    }
}
