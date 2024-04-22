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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDBContext _db;
        public OrderRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Order order)
        {
            _db.Update(order);
        }

        public void updateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.Orders.FirstOrDefault(o => o.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentId(int id, string paymentIntentId)
        {
            var orderFromDb = _db.Orders.FirstOrDefault(U => U.Id == id);

            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderFromDb.PaymentIntentId = paymentIntentId;
                orderFromDb.PaymentData = DateTime.Now;


            }
        }

        public OrderViewModel GetOrder(string userId)
        {
            var user = _db.UserProfiles.FirstOrDefault(u => u.UserId == userId);

            var OrderItem = new OrderViewModel
            {
                CustomerId = user.UserId,
                CustomerName = user.Name,
                City = user.City,
                Email = user.UserEmail,
                StreetAddress = user.StreetAddress,
                Phone = user.Contact,
                State = user.State,
                PostalCode = user.PostalCode,
                OrderItems = (from cart in _db.ShoppingCarts
                             where cart.SessionId == userId
                             join product in _db.Products on cart.ProductId equals product.Id
                             join size in _db.Sizes on cart.SizeId equals size.Id
                             select new OrderItemViewModel
                             {
                                 CartId = cart.Id,
                                 ProductId = cart.ProductId,
                                 SelectedSize = cart.Size.Sizes,
                                 Count = cart.count,
                                 Price = product.Price,
                                 ProductName = product.Title,
                                 Player = product.player.Name
                             }).ToList()
            };

            return OrderItem;
        }
    }
}
