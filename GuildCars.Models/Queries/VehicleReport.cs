using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleReport
    {

        public string MfgYear { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }

    }
}
