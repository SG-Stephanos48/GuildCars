using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class FeaturedVehicleItem
    {

        public int CarId { get; set; }

        public string MfgYear { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public decimal MSRP { get; set; }

        public string ImageFileName { get; set; }

    }
}
