﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Controllers.Frontend
{
    public class HomepageController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
