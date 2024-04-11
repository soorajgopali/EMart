using Microsoft.AspNetCore.Mvc;

namespace EMart.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
