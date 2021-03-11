using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class ModelEditViewModel
    {

        public IEnumerable<SelectListItem> Make { get; set; }
        public Model Model { get; set; }

    }
}