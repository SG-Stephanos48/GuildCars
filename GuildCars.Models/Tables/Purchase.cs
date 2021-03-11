using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Purchase
    {

        public int PurchaseId { get; set; }
        public int PurchaseTypeId { get; set; }
        public string PurchasePrice { get; set; }
        public DateTime PuchaseDate { get; set; }

    }
}
