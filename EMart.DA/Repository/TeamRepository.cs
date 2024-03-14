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
                                  join teamType in _db.TeamTypes
                                  on team.TeamTypeId equals teamType.Id
                                  select new TeamViewModel
                                  {
                                      Id = team.Id,
                                      Name = team.Name,
                                      ImageUrl = team.ImageUrl,
                                      TeamTypeId = team.TeamTypeId,
                                      TeamTypeName = teamType.Name
                                  })
                            .ToList();

            return teamViewModels;
        }

        public void Update(Team team)
        {
            _db.Teams.Update(team);
        }
    }
}
