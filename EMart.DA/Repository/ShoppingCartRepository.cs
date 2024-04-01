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
        public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
        {
            private readonly ApplicationDBContext _db;   
            public ShoppingCartRepository(ApplicationDBContext db) : base(db)
            {
                _db = db;
            }

            public CartViewModel GetById(int id)
            {
                //var cartobj = (from cart in _db.ShoppingCarts
                //               join product in _db.Products on cart.ProductId equals product.Id
                //               join size in _db.Sizes on cart.SizeId equals size.Id
                //               select new CartViewModel
                //               {
                //                   Id = cart.Id,
                //                   count = cart.count,
                //                   SizeName = size.Sizes,
                //               }).FirstOrDefault();
                return new CartViewModel();
            }

        public void Update(ShoppingCart shoppingCart)
        {
            _db.ShoppingCarts.Update(shoppingCart);
            _db.SaveChanges();
        }
    }
    }
