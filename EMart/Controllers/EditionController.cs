using EMart.DA.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Controllers
{
    public class EditionController : Controller
    {
        private readonly IUnitOfWork _unit;
        public EditionController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IActionResult Index()
        {
            var editions  = _unit.Edition.GetAll().ToList();
            return View(editions);
        }
    }
}
