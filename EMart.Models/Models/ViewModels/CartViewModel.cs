using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models.ViewModels
{
    public class CartViewModel
    {
        public int ProductId { get; set; }
        public string SelectedSize { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string SessionId { get; set; }
    }
}
