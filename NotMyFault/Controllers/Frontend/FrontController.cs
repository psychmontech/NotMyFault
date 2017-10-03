using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Controllers.Frontend
{
    public class FrontController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
