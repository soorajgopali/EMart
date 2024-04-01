using EMart.DA.Repository.IRepository;
using EMart.Models;
using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;

namespace EMart.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unit;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IUnitOfWork unit)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _unit = unit;
        }

        public IActionResult Index()
        {
            var parentModel = new ParentViewModel
            {
                productList = _unit.Product.GetList(),
                LeagueList = _unit.League.GetList()
            };
            return View(parentModel);
        }

        public IActionResult Details(int productId)
        {
            var model = _unit.Product.GetById(productId);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddCart(CartViewModel model)
        {
            try
            {
                var sizeObj = _unit.Size.Get(x => x.Sizes == model.SelectedSize);

                var cart = new ShoppingCart
                {
                    ProductId = model.ProductId,
                    SizeId = Convert.ToInt32(sizeObj.Id),
                    count = model.Count,
                    TotalPrice = model.Price,
                    SessionId = model.SessionId,
                };

                ShoppingCart existingCart = _unit.ShoppingCart.Get(u => u.ProductId == model.ProductId && u.SizeId == Convert.ToInt32(sizeObj.Id) && u.SessionId == model.SessionId);

                if (existingCart != null)
                {
                    existingCart.count += model.Count;
                    _unit.ShoppingCart.Update(existingCart);
                }
                else
                {
                    _unit.ShoppingCart.Add(cart);
                }

                return Json(new { success = true, message = "Cart updated successfully." });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "An error occurred while updating the cart." });
            }
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

