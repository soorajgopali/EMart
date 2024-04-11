using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        CartViewModel GetById(int id);
        void Update(ShoppingCart shoppingCart);

        int GetCartCount(string sessionId);

        IEnumerable<CartViewModel> GetCartItems(string sessionId);


    }
}
