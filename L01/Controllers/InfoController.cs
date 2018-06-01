using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L01.Data;
using L01.Models;
using Microsoft.AspNetCore.Mvc;

namespace L01.Controllers
{
    public class InfoController : Controller
    {
        private readonly GPContext _context;

        public InfoController(GPContext context)
        {
            _context = context;
        }

        public IActionResult ListRaces()
        {
            ViewData["BannerNr"] = 0;

            var races = _context.Races.OrderBy(r => r.Date);
            return View(races.ToList());
        }

        public IActionResult BuildMap()
        {
            ViewData["BannerNr"] = 0;

            ViewData["Races"] = _context.Races.ToList<Race>();

            return View();
        }

        public IActionResult ShowRace(int id)
        {
            ViewData["BannerNr"] = 0;

            ViewData["Race"] = _context.Races.Where(r => r.RaceId == id).Single();

            return View();
        }

        public IActionResult ListRiders()
        {
            ViewData["BannerNr"] = 1;

            var riders = _context.Riders.OrderBy(r => r.Number);
            return View(riders.ToList());
        }
    }
}