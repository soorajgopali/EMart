using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String ImageUrl { get; set; }
        public int LeagueId { get; set; }
        [ForeignKey("LeagueId")]
        public League League { get; set;}

    }
}
