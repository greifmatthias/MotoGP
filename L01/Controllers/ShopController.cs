using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L01.Data;
using L01.Models;
using L01.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace L01.Controllers
{
    public class ShopController : Controller
    {
        private readonly GPContext context;

        public ShopController(GPContext context)
        {
            this.context = context;
        }

        public IActionResult OrderTicket()
        {
            ViewData["BannerNr"] = 3;

            ViewData["Countries"] = new SelectList(context.Countries.OrderBy(c => c.Name), "CountryId", "Name");
            ViewData["Races"] = context.Races.OrderBy(c => c.Name).ToList<Race>();

            return View();
        }

        public IActionResult ConfirmOrder(int id)
        {
            ViewData["BannerNr"] = 3;

            Ticket ticket = context.Tickets.Include(r => r.Race).Where(t => t.TicketId == id).Single();

            return View(ticket);
        }

        public IActionResult ListTickets(int? RaceId)
        {
            ViewData["BannerNr"] = 3;

            var tickets = from t in context.Tickets.Include(c => c.Country).Include(r => r.Race).OrderBy(t => t.OrderDate) select t;

            if(RaceId != null && RaceId != 0)
            {
                tickets = tickets.Where(t => t.RaceId == RaceId);
            }

            var vm = new ListTicketsViewModel();
            vm.Tickets = tickets.ToList();
            vm.Races = new SelectList(context.Races.OrderBy(r => r.Name), "RaceId", "Name");
            vm.RaceId = (RaceId == null) ? 0 : (int)RaceId;

            return View(vm);
        }
        
        public IActionResult EditTicket(int id)
        {
            ViewData["BannerNr"] = 3;

            var ticket = context.Tickets.Include(c => c.Country).Include(r => r.Race).Where(t => t.TicketId == id).Single();

            return View(ticket);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Register([Bind("TicketId, Paid")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Attach(ticket);
                context.Entry(ticket).Property(t => t.Paid).IsModified = true;
                context.SaveChanges();

                return RedirectToAction("ListTickets", new { id = ticket.RaceId });
            }

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create([Bind("TicketId, Name, Email, Address, Number, CountryId, RaceId")] Ticket ticket)
        {
            ticket.Paid = false;
            ticket.OrderDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                context.Add(ticket);
                context.SaveChanges();

                return RedirectToAction("ConfirmOrder", new { id = ticket.TicketId });
            }
            
            return View();
        }
    }
}