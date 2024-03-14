using EMart.DA.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Controllers
{
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
