using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        List<ProductViewModel> GetList();

        ProductViewModel GetById(int id);
        List<ProductViewModel> GetByLeagueId(int leagueId);
        List<ProductViewModel> GetByTeamId(int teamId);
        List<ProductViewModel> GetByType(int editionId, int specificId, int brandId);
    }
}
