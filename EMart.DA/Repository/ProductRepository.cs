using EMart.DA.Data;
using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
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
            var query = (from p in _db.Products
                        join cat in _db.Categories on p.CategoryId equals cat.Id
                        join b in _db.Brands on p.BrandId equals b.Id
                        join e in _db.Editions on p.EditionId equals e.Id
                        join pl in _db.Players on p.PlayerId equals pl.Id
                        join sp in _db.Specifics on p.SpecificId equals sp.Id
                        join t in _db.Teams on p.TeamId equals t.Id
                        select new ProductViewModel
                        {
                           Id= p.Id,
                            Title= p.Title,
                            ProductCode= p.ProductCode,
                            Description= p.Description,
                            Price= p.Price,
                            ImageUrl=p.ImageUrl,
                            Year=p.Year,
                            Season=p.Season,
                            CategoryName = cat.Name,
                            BrandName = b.Name,
                            EditionName = e.Name,
                            PlayerName = pl.Name,
                            SpecifiName = sp.Name,
                            TeamName = t.Name,
                            ProductSize = string.Join(",", _db.ProductSizes
                                                              .Where(ps => ps.ProductId == p.Id)
                                                              .Join(_db.Sizes, ps => ps.SizesId, s => s.Id, (ps, s) => s.Sizes)
                                                              .DefaultIfEmpty())
                        }).ToList();
    


            

            string sql = string.Format($@"
                SELECT p.Id 
                , p.Title 
                , p.ProductCode 
                , p.Description
                , p.Price
                , p.ImageUrl
                , p.Year
                , p.Season
                , CAT.Name AS CategoryName
                , B.Name AS BrandName
                , E.Name AS EditionName
                , PL.Name AS PlayerName
                , SP.Name AS SpecifiName
                , T.Name AS TeamName
                , ISNULL((SELECT STRING_AGG(Sizes, ',') FROM DBO.Sizes WHERE Id IN (SELECT SizesId FROM DBO.ProductSizes WHERE ProductId = P.Id)), '') AS ProductSize
                FROM DBO.Products P
                INNER JOIN DBO.Categories CAT ON CAT.Id = P.CategoryId
                INNER JOIN DBO.Brands B ON B.Id = P.BrandId
                INNER JOIN DBO.Editions E ON E.Id = P.EditionId
                INNER JOIN DBO.Players PL ON PL.Id = P.PlayerId
                INNER JOIN DBO.Specifics SP ON SP.Id = P.SpecificId
                INNER JOIN DBO.Teams T ON T.Id = P.TeamId
                ");

            return query;

        }
        public ProductViewModel GetById(int id)
        {
            var productObj = (from product in _db.Products
                              join category in _db.Categories on product.CategoryId equals category.Id
                              join brand in _db.Brands on product.BrandId equals brand.Id
                              join edition in _db.Editions on product.EditionId equals edition.Id
                              join player in _db.Players on product.PlayerId equals player.Id
                              join specific in _db.Specifics on product.SpecificId equals specific.Id
                              join team in _db.Teams on product.TeamId equals team.Id
                              where product.Id == id
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
                                  ProductSize = string.Join(",", _db.ProductSizes
                                                                    .Where(ps => ps.ProductId == product.Id)
                                                                    .Join(_db.Sizes, ps => ps.SizesId, s => s.Id, (ps, s) => s.Sizes)
                                                                    .DefaultIfEmpty()),

                              }).FirstOrDefault();

            return productObj;
        }



    }
}
