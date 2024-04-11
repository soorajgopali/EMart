using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EMart.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unit;
        public CartController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpPost]
        public IActionResult CartItems(string sessionId)
        {
            if (string.IsNullOrEmpty(sessionId))
            {
                return BadRequest("SessionId is missing or invalid.");
            }

            try
            {
                IEnumerable<CartViewModel> cartItems = _unit.ShoppingCart.GetCartItems(sessionId);

                if (cartItems == null || !cartItems.Any())
                {
                    return View(new List<CartViewModel>());
                }

                return View(cartItems);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving cart items: {ex.Message}");
                return StatusCode(500, "An error occurred while retrieving cart items.");
            }
        }

        [HttpPost]
        public IActionResult UpdateSize(int cartId, string newSize)
        {
            try
            {
                var cartItem = _unit.ShoppingCart.Get(x => x.Id == cartId);
                if (cartItem != null)
                {
                    var sizeObj = _unit.Size.Get(x => x.Sizes == newSize);
                    if (sizeObj != null)
                    {
                        cartItem.SizeId = sizeObj.Id;

                        _unit.ShoppingCart.Update(cartItem);
                        _unit.Save();

                        return Ok("Size updated successfully.");
                    }
                    else
                    {
                        return NotFound("Size not found.");
                    }
                }
                else
                {
                    return NotFound("Cart item not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating size: {ex.Message}");
                return StatusCode(500, "An error occurred while updating size.");
            }
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int cartId, int newQuantity)
        {
            try
            {
                var cartItem = _unit.ShoppingCart.Get(x => x.Id == cartId);
                if (cartItem != null)
                {
                    var product = _unit.Product.Get(p => p.Id == cartItem.ProductId);


                    cartItem.count = newQuantity;
                    _unit.ShoppingCart.Update(cartItem);
                    _unit.Save();

                    decimal totalPrice = product.Price * newQuantity;

                    return Json(new { success = true, totalPrice = totalPrice });
                }
                else
                {
                    return Json(new { success = false, message = "Cart item not found." });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating quantity: {ex.Message}");
                return StatusCode(500, "An error occurred while updating quantity.");
            }
        }

        [HttpPost]
        public IActionResult RemoveItem(int cartId)
        {
            try
            {
                var cartItem = _unit.ShoppingCart.Get(u => u.Id == cartId);
                if (cartItem != null)
                {
                    
                    _unit.ShoppingCart.Remove(cartItem);
                    _unit.Save();
                    return Ok();    
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500); 
            }
        }

    }
}
