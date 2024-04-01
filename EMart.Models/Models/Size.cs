using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Sizes {  get; set; } 
        public bool IsActive { get; set; }
    }
}
