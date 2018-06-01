using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace L01.Models
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryId { get; set; }

        public string Name { get; set; }

        public List<Rider> Riders { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
