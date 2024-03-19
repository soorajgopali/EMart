using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models.ViewModels
{
    public class ProductVM
    {
       
        public IEnumerable<Product> ProductList { get; set; }
    }
}
