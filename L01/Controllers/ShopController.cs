using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L01.Data;
using L01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            Ticket ticket = context.Tickets.Where(t => t.TicketId == id).Single();
            ticket.Race = context.Races.Where(r => r.RaceId == ticket.RaceId).Single();

            return View(ticket);
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