using L01.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L01.ViewModels
{
    public class SelectRaceViewModel
    {
        public SelectList Races { get; set; }
        public int RaceId { get; set; }
        public Race race { get; set; }
    }
}
