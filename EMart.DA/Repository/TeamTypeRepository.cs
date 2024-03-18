using EMart.DA.Data;
using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository
{
    public class TeamTypeRepository : Repository<TeamType>, ITeamTypeRepository
    {
        private readonly ApplicationDBContext _db;
        public TeamTypeRepository(ApplicationDBContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(TeamType teamType)
        {
            _db.TeamTypes.Update(teamType);
        }
    }
}
