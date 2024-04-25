using EMart.DA.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Areas.Customer.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unit;

        public SearchController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
