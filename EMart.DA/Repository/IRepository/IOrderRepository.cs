using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order order);
        void updateStatus(int id,string orderStatus,string?paymentStatus = null);
        void UpdateStripePaymentId(int id,string paymentIntentId);
        OrderViewModel GetOrder(string userId);

    }
}
