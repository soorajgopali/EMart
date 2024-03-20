using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public IFormFile? Image {  get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Season { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty ;

        public int EditionId {  get; set; }
        public string EditionName { get; set;} = string.Empty ;

        public int PlayerId { get; set; }
        public string PlayerName { get; set;} = string.Empty;

        public int SpecificId {  get; set; }
        public string SpecifiName { get; set;} = string.Empty ;

        public int TeamId { get; set; }
        public string TeamName { get; set;}= string.Empty ;
    }
}
