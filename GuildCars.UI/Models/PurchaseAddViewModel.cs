﻿using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class PurchaseAddViewModel
    {

        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> PurchaseTypes { get; set; }
        public Car Car { get; set; }
        public Purchase Purchase { get; set; }
        public Contact Contact { get; set; }

    }
}