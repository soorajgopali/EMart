using EMart.DA.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizeController : Controller
    {
        private readonly IUnitOfWork _Unit;
        public SizeController(IUnitOfWork unit)
        {
            _Unit = unit;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
