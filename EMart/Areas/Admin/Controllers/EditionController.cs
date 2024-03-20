using EMart.DA.Repository.IRepository;
using EMart.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class EditionController : Controller
    {
        private readonly IUnitOfWork _unit;
        public EditionController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IActionResult Index()
        {
            var editions = _unit.Edition.GetAll().ToList();
            return View(editions);
        }
    }
}
