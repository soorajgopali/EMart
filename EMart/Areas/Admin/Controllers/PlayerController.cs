using EMart.DA.Repository;
using EMart.DA.Repository.IRepository;
using EMart.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

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
