using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class UserEditViewModel
    {

        public IEnumerable<SelectListItem> Role { get; set; }
        public User User { get; set; }

    }
}