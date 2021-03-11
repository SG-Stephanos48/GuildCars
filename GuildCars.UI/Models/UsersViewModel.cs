using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class UsersViewModel
    {

        public IEnumerable<SelectListItem> Role { get; set; }

        public IEnumerable<SelectListItem> UserRole { get; set; }

        public User User { get; set; }

    }
}