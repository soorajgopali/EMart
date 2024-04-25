using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMart.Models.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category category { get; set; }

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand brand { get; set; }

        public int EditionId { get; set; }
        [ForeignKey("EditionId")]
        public Edition edition { get; set; }

        public int PlayerId {  get; set; }
        [ForeignKey("PlayerId")]
        public Player player { get; set; }

        public int SpecificId { get; set; }
        [ForeignKey("SpecificId")]
        public Specific specific { get; set; }

        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team team { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        public string Season { get; set; }


    }
}
