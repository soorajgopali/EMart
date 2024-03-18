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
    public class PlayerRepository :Repository<Player>, IPlayerRepository
    {
        private readonly ApplicationDBContext _db;
        public PlayerRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
    }
}
