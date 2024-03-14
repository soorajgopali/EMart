using EMart.DA.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Controllers
{
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _Unit;
        public BrandController(IUnitOfWork unit)
        {
            _Unit = unit;
        }
        public IActionResult Index()
        {
            var brands = _Unit.Brand.GetAll().ToList();
            return View(brands);
        }
    }
}
