using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace L01.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeamId { get; set; }

        public string Name { get; set; }
        public string Logo { get; set; }

        public ICollection<Rider> Riders { get; set; }
    }
}
