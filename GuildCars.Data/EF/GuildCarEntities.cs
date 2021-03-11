using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.EF
{
    public class GuildCarEntities : DbContext
    {

        public GuildCarEntities() : base("GuildCar")
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<PurchaseType> PurchaseTypes { get; set; }
        public DbSet<Special> Specials { get; set; }
    }
}
