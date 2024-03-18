using EMart.DA.Repository;
using EMart.DA.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IUnitOfWork _unit;
        public PlayerController(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public IActionResult Index()
        {
            var players = _unit.Player.GetAll().ToList();
            return View(players);
        }
    }
}
