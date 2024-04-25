using EMart.DA.Data;
using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository
{
    public class BrandRepository :Repository<Brand>, IBrandRepository
    {
        private readonly ApplicationDBContext _db;
        public BrandRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public List<BrandViewModel> GetList()
        {
            var query = (from brand in _db.Brands
                         select new BrandViewModel
                         {
                             Id = brand.Id,
                             Name = brand.Name,
                         }).ToList();

            return query;
        }
    }
}
