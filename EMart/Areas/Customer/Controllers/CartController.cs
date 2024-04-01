using EMart.DA.Repository.IRepository;
using EMart.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
/*
        [HttpPost]
        public IActionResult Index(CartViewModel model)
        {
            if(ModelState.IsValid)
            {
            var cartViewModelById = _unit.ShoppingCart.GetById(model.Id);
                return RedirectToAction("Index", "Cart");
            }
            else
            {
            return View(model);
            }
        }*/
    }
}
