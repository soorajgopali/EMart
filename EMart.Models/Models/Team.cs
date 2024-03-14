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
        public int TeamTypeId { get; set; }
        [ForeignKey("TeamTypeId")]
        public TeamType Type { get; set; }

    }
}
