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
        void Save();
    }
}
