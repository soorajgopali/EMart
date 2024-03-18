using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository.IRepository
{
    public interface ILeagueRepository : IRepository<League>
    {
        List<LeagueViewModel> GetList();
    }
}
