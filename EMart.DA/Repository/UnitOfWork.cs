using EMart.DA.Data;
using EMart.DA.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db;
        public ICategoryRepository Category {  get; private set; }

        public ITeamTypeRepository TeamType {  get; private set; }

        public ITeamRepository Team { get; private set; }

        public UnitOfWork (ApplicationDBContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            TeamType = new TeamTypeRepository(_db);
            Team = new TeamRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
