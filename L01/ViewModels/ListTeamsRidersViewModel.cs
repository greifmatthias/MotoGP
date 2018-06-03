using L01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L01.ViewModels
{
    public class ListTeamsRidersViewModel
    {
        public List<Team> Teams { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
}
