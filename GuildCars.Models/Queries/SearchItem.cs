using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class SearchItem
    {

        public int CarId { get; set; }

        public string MfgYear { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string BodyStyleName { get; set; }

        public string CarTypeName { get; set; }

        public string TransName { get; set; }

        public string ColorName { get; set; }

        public string InteriorName { get; set; }

        public string Mileage { get; set; }

        public string VIN { get; set; }

        public decimal SalesPrice { get; set; }

        public decimal MSRP { get; set; }

        public string ImageFileName { get; set; }

        public DateTime PurchaseDate { get; set; }

        public bool Feature { get; set; }

    }
}
