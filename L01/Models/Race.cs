using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L01.Models
{
    public class Race
    {
        public int RaceId { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public String Description { get; set; }
        public int Length { get; set; }
        public DateTime Date { get; set; }
        public String Country { get; set; }
    }
}
