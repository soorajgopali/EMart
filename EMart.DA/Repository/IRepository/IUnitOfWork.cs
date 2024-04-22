using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        ITeamTypeRepository TeamType { get; }
        ITeamRepository Team { get; }
        IPlayerRepository Player { get; }
        ISpecificRepository Specific { get; }
        IBrandRepository Brand { get; }
        IEditionrepository Edition { get; }
        ILeagueRepository League { get; }
        IProductRepository Product { get; }
        IShoppingCartRepository ShoppingCart { get; }
        ISizeRepository Size { get; }
        IProductsizeRepository Productsize { get; }
        IUserRepository User { get; }
        IOrderRepository Order { get; }
        void Save();
    }
}
