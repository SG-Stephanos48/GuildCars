using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class CarSearchParameters
    {

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string MagicTerm { get; set; }
        public string MinMfgYear { get; set; }
        public string MaxMfgYear { get; set; }

    }
}
