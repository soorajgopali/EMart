using EMart.DA.Repository;
using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Reflection;

namespace EMart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(IUnitOfWork unit, IWebHostEnvironment webHostEnvironment)
        {
            _unit = unit;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var categories = _unit.Category.GetAll().OrderBy(u=>u.DisplayOrder).ToList();
            return View(categories);
        }


        public IActionResult Create()
        {
            var maxDisplayOrder = _unit.Category.GetAll().Max(c => (int?)c.DisplayOrder) ?? 0;

            ViewBag.MaxDisplayOrder = maxDisplayOrder + 1;

            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (model.Image != null)
                    {
                        string filename = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
                        string filePath = Path.Combine(wwwRootPath, @"Images/Category");

                        using (var fileStream = new FileStream(Path.Combine(filePath, filename), FileMode.Create))
                        {
                            model.Image.CopyTo(fileStream);
                        }

                        model.ImageUrl = @"/Images/Category/" + filename;
                    }

                    var category = new Category
                    {
                        Name = model.Name,
                        ImageUrl = model.ImageUrl
                    };

                    _unit.Category.Add(category);
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

        public IActionResult Update(int? id)
        {

            if (id == null && id == 0)
                return NotFound();
            var categoryObj = _unit.Category.Get(u => u.Id == id);

            if (categoryObj == null)
            {
                return NotFound();
            }



            var catVM = new CategoryViewModel()
            {
                ImageUrl = categoryObj.ImageUrl,
                DisplayOrder = categoryObj.DisplayOrder,
                Name = categoryObj.Name,
            };
            return View(catVM);
        }


        [HttpPost]
        public IActionResult Update(CategoryViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    if (model.Image != null)
                    {
                        string filename = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
                        string filePath = Path.Combine(wwwRootPath, @"Images/Category");

                        if (!string.IsNullOrEmpty(model.ImageUrl))
                        {
                            var oldImgPath = Path.Combine(wwwRootPath, model.ImageUrl).TrimStart('/');
                        }
                        using (var fileStream = new FileStream(Path.Combine(filePath, filename), FileMode.Create))
                        {
                            model.Image.CopyTo(fileStream);
                        }
                        model.ImageUrl = @"/Images/Category/" + filename;
                    }

                    var category = _unit.Category.Get(x => x.Id == model.Id);
                    if (category == null)
                    {
                        throw new Exception("Category not found to update.");
                    }

                    category.Id = model.Id;
                    category.Name = model.Name;
                    category.DisplayOrder = model.DisplayOrder;
                    category.ImageUrl = model.ImageUrl;

                    _unit.Category.Update(category);
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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var catObj = _unit.Category.Get(u => u.Id == id);
                if (catObj is null)
                    throw new Exception($"Data Not Found To Delete.");

                _unit.Category.Remove(catObj);
                _unit.Save();

                return Json(new { success = true, message = $"Category with name {catObj.Name} deleted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error while deleting data:{ex.Message}" });
            }
        }

    }
}

