using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L01.Data;
using L01.Models;
using L01.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult SelectRace(int? RaceId)
        {
            ViewData["BannerNr"] = 0;

            Race race = new Race();
            if(RaceId != null && RaceId != 0)
            {
                race = _context.Races.Where(r => r.RaceId == RaceId).Single();
            }

            var SelectRaceVM = new SelectRaceViewModel();
            SelectRaceVM.race = race;
            SelectRaceVM.Races = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Races.OrderBy(r => r.Name), "RaceId", "Name");
            SelectRaceVM.RaceId = (RaceId == null) ? 0 : (int)RaceId;

            return View(SelectRaceVM);
        }

        public IActionResult ListRiders()
        {
            ViewData["BannerNr"] = 1;

            var riders = _context.Riders.OrderBy(r => r.Number);
            return View(riders.ToList());
        }

        public IActionResult ListTeams()
        {
            ViewData["BannerNr"] = 2;

            return View(_context.Teams.Include(r => r.Riders).OrderBy(t => t.Name).ToList());
        }

        public IActionResult ListTeamsRiders(int? id)
        {
            ViewData["BannerNr"] = 2;

            Team team = new Team();
            if (id != null && id != 0)
            {
                team = _context.Teams.Include(r => r.Riders).Where(t => t.TeamId == id).Single();
            }

            var vm = new ListTeamsRidersViewModel();
            vm.Teams = _context.Teams.OrderBy(t => t.Name).ToList();
            vm.TeamId = (id == null) ? 0 : (int)id;
            vm.Team = team;

            return View(vm);
        }
    }
}