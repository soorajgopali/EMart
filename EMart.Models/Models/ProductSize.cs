using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models
{
    public class ProductSize
    {
        public int Id { get; set; }

        public int SizesId { get; set; }
        [ForeignKey("SizesId")]
        public Size size { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product product { get; set; }
    }
}
