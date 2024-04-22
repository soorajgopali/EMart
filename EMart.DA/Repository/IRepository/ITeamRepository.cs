using EMart.Models.Models;
using EMart.Models.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository.IRepository
{
    public interface ITeamRepository : IRepository<Team>
    {
        List<TeamViewModel> GetById(int teamId);
        List<TeamViewModel> GetList();
        List<TeamViewModel> GetListByLeague(int leagueId);

        void Update (Team team);
    }
}
