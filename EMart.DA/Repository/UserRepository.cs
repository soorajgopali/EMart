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
    public class UserRepository :Repository<UserProfile>, IUserRepository
    {
        private readonly ApplicationDBContext _db;
        public UserRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UserProfile userProfile)
        {
            _db.UserProfiles.Update(userProfile);
        }


        public UserProfileWithShoppingCartViewModel GetCheckOut(string userId)
        {
            var user = _db.UserProfiles.FirstOrDefault(u => u.UserId == userId);

            var checkOutItem = new UserProfileWithShoppingCartViewModel
            {
                userId = user.UserId,
                Name = user.Name,
                City = user.City,
                UserEmail = user.UserEmail,
                StreetAddress = user.StreetAddress,
                Contact = user.Contact,
                State = user.State,
                PostalCode = user.PostalCode,
                CartItems = (from cart in _db.ShoppingCarts
                             where cart.SessionId == userId
                             join product in _db.Products on cart.ProductId equals product.Id
                             join size in _db.Sizes on cart.SizeId equals size.Id
                             select new CartItemViewModel
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
                                 Player = product.player.Name
                             }).ToList()
            };

            return checkOutItem;
        }

    }
}
