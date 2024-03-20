using EMart.DA.Repository.IRepository;
using EMart.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
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
