using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models
{
    public class TeamType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
