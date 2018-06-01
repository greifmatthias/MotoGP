using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L01.Models;
using Microsoft.AspNetCore.Mvc;

namespace L01.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult ListRaces()
        {
            ViewData["BannerNr"] = 0;
            return View();
        }

        public IActionResult BuildMap()
        {
            ViewData["BannerNr"] = 0;

            ViewData["Races"] = new List<Race>()
            {
                new Race() { RaceId = 1, X = 517, Y = 19, Name = "Assen" },
                new Race() { RaceId = 2, X = 859, Y = 249, Name = "Losail Circuit" },
                new Race() { RaceId = 3, X = 194, Y = 428, Name = "Autódromo Termas de Río Hondo" }
            };

            return View();
        }
    }
}