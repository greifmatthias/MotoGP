using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace L01.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult OrderTicket()
        {
            ViewData["BannerNr"] = 3;

            return View();
        }

        public IActionResult ConfirmOrder()
        {
            ViewData["BannerNr"] = 3;

            return View();
        }
    }
}