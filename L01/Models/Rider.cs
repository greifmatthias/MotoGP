using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L01.Models
{
    public class Rider
    {
        public int RiderId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public Country Country { get; set; }
        public Team Team { get; set; }
        public string Bike { get; set; }
        public int Number { get; set; }
        public int TeamId { get; set; }
        public int CountryId { get; set; }
    }
}
