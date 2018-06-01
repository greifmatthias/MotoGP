using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L01.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int RaceId { get; set; }
        public int Number { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }

        public Country Country { get; set; }
        public Race Race { get; set; }
    }
}
