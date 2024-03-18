using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Controllers
{
    public class LeagueController : Controller
    {
        private readonly IUnitOfWork _Unit;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public LeagueController(IUnitOfWork unit, IWebHostEnvironment webHostEnvironment)
        {
            _Unit = unit;
            _WebHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var leaguViewModel = _Unit.League.GetList();
            return View(leaguViewModel);
        }

        public IActionResult Create()
        {
            ViewBag.TeamTypes = _Unit.TeamType.GetAll().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(LeagueViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _WebHostEnvironment.WebRootPath;
                    if (model.Image != null)
                    {
                        string filename = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                        string filepath = Path.Combine(wwwRootPath, @"Images/League");

                        using (var filestream = new FileStream(Path.Combine(filepath, filename), FileMode.Create))
                        {
                            model.Image.CopyTo(filestream);
                        }
                        model.ImageUrl = @"/Images/League/" + filename;
                    }
                    var league = new League
                    {
                        Name = model.Name,
                        ImageUrl = model.ImageUrl,
                        TeamTypeId = model.TeamTypeId,
                    };
                    _Unit.League.Add(league);
                    _Unit.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return View();
        }
    }
}
