using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EMart.Controllers
{
    public class TeamController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeamController(IUnitOfWork unit, IWebHostEnvironment webHostEnvironment)
        {
            _unit = unit;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var teamViewModels = _unit.Team.GetList();
            return View(teamViewModels);
        }
        public IActionResult Create()
        {
            ViewBag.TeamTypes = _unit.TeamType.GetAll().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (model.Image != null)
                    {
                        string filename = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                        string filepath = Path.Combine(wwwRootPath, @"Images/Teams");

                        using (var filestream = new FileStream(Path.Combine(filepath, filename), FileMode.Create))
                        {
                            model.Image.CopyTo(filestream);
                        }

                        model.ImageUrl = @"/Images/Teams" + filename;
                    }

                    var team = new Team
                    {
                        Name = model.Name,
                        ImageUrl = model.ImageUrl,
                        TeamTypeId = model.TeamTypeId,
                    };
                    _unit.Team.Add(team);
                    _unit.Save();
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

