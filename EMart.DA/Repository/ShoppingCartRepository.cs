using EMart.DA.Data;
using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
        public int GetCartCount(string sessionId)
        {
            int totalQuantity = _db.ShoppingCarts
                .Where(u => u.SessionId == sessionId)
                .Sum(u => u.count);

            return totalQuantity;
        }

        public IEnumerable<CartViewModel> GetCartItems(string sessionId)
        {
            return _db.ShoppingCarts
                .Where(u => u.SessionId == sessionId)
                .Join(_db.Products,
                    cart => cart.ProductId,
                    product => product.Id,
                    (cart, product) => new CartViewModel
                    {
                        CartId = cart.Id,
                        ProductId = cart.ProductId,
                        SelectedSize = cart.Size.Sizes,
                        Count = cart.count,
                        Price = product.Price,
                        ImageUrl = product.ImageUrl,
                        Title = product.Title,
                        Season = product.Season,
                        TeamName = product.team.Name,
                        Player = product.player.Name,
                        AvailableSizes = string.Join(", ", _db.ProductSizes
                                                              .Where(ps => ps.ProductId == product.Id)
                                                              .Join(_db.Sizes, ps => ps.SizesId, s => s.Id, (ps, s) => s.Sizes)
                                                              .Distinct())
                    })
                .ToList();
        }


    }
}
