﻿using EMart.DA.Data;
using EMart.DA.Repository.IRepository;
using EMart.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Repository
{
    public class SpecificRepository :Repository<Specific>, ISpecificRepository
    {
        private readonly ApplicationDBContext _db;
        public SpecificRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
    }
}
