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
    public class LeageuRepository :Repository<League>, ILeagueRepository
    {
        private readonly ApplicationDBContext _db;
        public LeageuRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public List<LeagueViewModel> GetList()
        {
            var leagueViewModels =(from league in _db.Leagues
                                   join teamType in _db.TeamTypes
                                   on league.TeamTypeId equals teamType.Id
                                   select new LeagueViewModel
                                   {
                                       Id = league.Id,
                                       Name = league.Name,
                                       ImageUrl = league.ImageUrl,
                                       TeamTypeId = teamType.Id,
                                       TeamTypeName = teamType.Name,
                                   })
                                   .ToList();
            return leagueViewModels;
        }
    }
}
