using EMart.DA.Data;
using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository
{
    public class ProductsizeRepository :Repository<ProductSize>, IProductsizeRepository
    {
        private readonly ApplicationDBContext _db;
        public ProductsizeRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
    }
}
