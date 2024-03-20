using EMart.DA.Repository.IRepository;
using EMart.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class SpecificController : Controller
    {
        private readonly IUnitOfWork _unit;
        public SpecificController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IActionResult Index()
        {
            var specifics = _unit.Specific.GetAll().ToList();
            return View(specifics);
        }
    }
}
