using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EMart.DA.Data;
using EMart.Models.Models;
using System.Security.Claims;
using EMart.DA.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using EMart.Models.Models.ViewModels;
using Stripe.Checkout;


namespace EMart.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class CheckOutController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public CheckOutController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IHttpContextAccessor contextAccessor, IUnitOfWork unit)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _contextAccessor = contextAccessor;
            _unit = unit;
        }

        public IActionResult Shipping(string netuser = "")
        {

            ViewBag.IsUserLogin = netuser;
            ViewBag.CustomerId = _contextAccessor.HttpContext.Session.GetString("customerId");

            var userProfile = new UserProfile();
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                userProfile = _unit.User.Get(u => u.UserId == userId);
            }

            return View(userProfile);
        }


        [HttpPost]
        public IActionResult Continue(UserProfile userProfile)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                {
                    return RedirectToAction("Error", "Home");
                }

                var existingProfile = _unit.User.Get(u => u.UserId == userId);

                if (existingProfile == null)
                {
                    existingProfile = new UserProfile();
                }

                existingProfile.Name = userProfile.Name;
                existingProfile.StreetAddress = userProfile.StreetAddress;
                existingProfile.City = userProfile.City;
                existingProfile.State = userProfile.State;
                existingProfile.PostalCode = userProfile.PostalCode;
                existingProfile.Contact = userProfile.Contact;
                existingProfile.UserEmail = userProfile.UserEmail;

                if (string.IsNullOrEmpty(existingProfile.UserId))
                {
                    _unit.User.Add(existingProfile);
                }
                else
                {
                    _unit.User.Update(existingProfile);
                }

                _unit.Save();

                var CheckOutItems = _unit.User.GetCheckOut(userId);

                return View(CheckOutItems);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        public IActionResult OrderComplete()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var OrderItem = _unit.Order.GetOrder(userId);


            var domain = "https://localhost:7280/Customer/CheckOut/Continue";
            var options = new Stripe.Checkout.SessionCreateOptions
            {
                SuccessUrl = domain,
                CancelUrl = domain,
                LineItems = new List<Stripe.Checkout.SessionLineItemOptions>(),
                Mode = "payment",
            };

            foreach (var item in OrderItem.OrderItems)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price*100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.ProductName,
                        }
                    },
                    Quantity = item.Count
                };
                options.LineItems.Add(sessionLineItem);
            }

            var service = new Stripe.Checkout.SessionService();
            Session session = service.Create(options);

            _unit.Order.UpdateStripePaymentId(OrderItem.Id, session.PaymentIntentId);
            _unit.Save();
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);

        }

    }
}
