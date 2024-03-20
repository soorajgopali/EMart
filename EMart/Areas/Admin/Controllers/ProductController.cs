using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using EMart.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unit, IWebHostEnvironment webHostEnvironment)
        {
            _unit = unit;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var productViewModel = _unit.Product.GetList();
            return View(productViewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Brand = _unit.Brand.GetAll().ToList();
            ViewBag.Category = _unit.Category.GetAll().ToList();
            ViewBag.Edition = _unit.Edition.GetAll().ToList();
            ViewBag.League = _unit.League.GetAll().ToList();
            ViewBag.Player = _unit.Player.GetAll().ToList();
            ViewBag.Specific = _unit.Specific.GetAll().ToList();
            ViewBag.Team = _unit.Team.GetAll().ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (model.Image != null)
                    {
                        string filename = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                        string filepath = Path.Combine(wwwRootPath, @"Images/Product");

                        using (var filestream = new FileStream(Path.Combine(filepath, filename), FileMode.Create))
                        {
                            model.Image.CopyTo(filestream);
                        }
                        model.ImageUrl = @"/Images/Product/" + filename;
                    }
                    var product = new Product
                    {
                        Title = model.Title,
                        ProductCode = model.ProductCode,
                        Description = model.Description,
                        Price = model.Price,
                        CategoryId = model.CategoryId,
                        BrandId = model.BrandId,
                        EditionId = model.EditionId,
                        TeamId = model.TeamId,
                        PlayerId = model.PlayerId,
                        SpecificId = model.SpecificId,
                        ImageUrl = model.ImageUrl,
                        Year = model.Year,
                        Season = model.Season,
                    };
                    _unit.Product.Add(product);
                    _unit.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return View(model);
        }
    }
}
