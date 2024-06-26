﻿using EMart.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository.IRepository
{
    public interface ITeamTypeRepository : IRepository<TeamType>
    {
        void Update (TeamType teamType);
    }
}
