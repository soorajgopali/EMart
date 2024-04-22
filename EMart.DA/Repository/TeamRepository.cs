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
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        private readonly ApplicationDBContext _db;
        public TeamRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public List<TeamViewModel> GetList()
        {
            var teamViewModels = (from team in _db.Teams
                                  join league in _db.Leagues on team.LeagueId equals league.Id
                                  join teamType in _db.TeamTypes on league.TeamTypeId equals teamType.Id
                                  select new TeamViewModel
                                  {
                                      Id = team.Id,
                                      Name = team.Name,
                                      ImageUrl = team.ImageUrl,
                                      LeagueName = league.Name,
                                      TeamTypeName = teamType.Name
                                  }).ToList();

            return teamViewModels;
        }

        public List<TeamViewModel> GetListByLeague(int leagueId)
        {
            var query = (from team in _db.Teams
                         join league in _db.Leagues on team.LeagueId equals league.Id
                         join teamType in _db.TeamTypes on league.TeamTypeId equals teamType.Id
                         where team.LeagueId == leagueId
                         select new TeamViewModel
                         {
                             Id = team.Id,
                             Name = team.Name,
                             ImageUrl = team.ImageUrl,
                         }).ToList();

            return query;
        }


        public List<TeamViewModel> GetById(int teamId)
        {
            var query = (from team in _db.Teams
                         join league in _db.Leagues on team.LeagueId equals league.Id
                         join teamType in _db.TeamTypes on league.TeamTypeId equals teamType.Id
                         where team.Id == teamId
                         select new TeamViewModel
                         {
                             Id = team.Id,
                             Name = team.Name,
                             ImageUrl = team.ImageUrl,
                         }).ToList();

            return query;
        }

        public void Update(Team team)
        {
            _db.Teams.Update(team);
        }
    }
}
