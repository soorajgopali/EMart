using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.Models.Models.ViewModels
{
    public class UserProfileWithShoppingCartViewModel
    {
        public string userId { get; set; }
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Contact { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
      

        
    }
    public class CartItemViewModel
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string SelectedSize { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Season { get; set; }
        public string TeamName { get; set; }
        public string Player { get; set; }
    }

}
