using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } 
        public string Season {  get; set; }
        public string TeamName { get; set; }
        public string AvailableSizes { get; set; }
        public string ProductSize { get; set; }
        public int CartId { get; set; }
        public string Player {  get; set; }
    }
}
