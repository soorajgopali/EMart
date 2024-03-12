using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Range(1, 100)]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

        [Required]
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
