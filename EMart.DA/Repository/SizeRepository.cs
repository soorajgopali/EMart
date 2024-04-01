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
    public class SizeRepository :Repository<Size>, ISizeRepository
    {
        private readonly ApplicationDBContext _db;
        public SizeRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

      /*  public List<SizeViewModel> GetList()
        {
            var sizeViewModel = (from size in _db.Sizes
                                 join product in _db.Products on size.ProductId equals product.Id
                                 select new SizeViewModel
                                 {
                                     Id = size.Id,
                                     Sizes = size.Sizes,
                                     IsActive = true,
                                     ProductId = product.Id,
                                     ProductName = product.Title,
                                 })
                                 .ToList();
            return sizeViewModel;*/
        }
    }

