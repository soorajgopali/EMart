using EMart.DA.Data;
using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDBContext _db;
        public ProductRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public List<ProductViewModel> GetList()
        {
            var productViewModel = (from product in _db.Products
                                    join category in _db.Categories on product.CategoryId equals category.Id
                                    join brand in _db.Brands on product.BrandId equals brand.Id
                                    join edition in _db.Editions on product.EditionId equals edition.Id
                                    join player in _db.Players on product.PlayerId equals player.Id
                                    join specific in _db.Specifics on product.SpecificId equals specific.Id
                                    join team in _db.Teams on product.TeamId equals team.Id
                                    select new ProductViewModel
                                    {
                                        Id = product.Id,
                                        Title = product.Title,
                                        ProductCode = product.ProductCode,
                                        Description = product.Description,
                                        Price = product.Price,
                                        ImageUrl = product.ImageUrl,
                                        Year = product.Year,
                                        Season = product.Season,
                                        CategoryId = product.CategoryId,
                                        CategoryName = category.Name,
                                        BrandId = brand.Id,
                                        BrandName = brand.Name,
                                        EditionId = edition.Id,
                                        EditionName = edition.Name,
                                        PlayerId = player.Id,
                                        PlayerName = player.Name,
                                        SpecificId = specific.Id,
                                        SpecifiName = specific.Name,
                                        TeamId = team.Id,
                                        TeamName = team.Name,
                                    })
                                     .ToList();
            return productViewModel;


        }


    }
}
