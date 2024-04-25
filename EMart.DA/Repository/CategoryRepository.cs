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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _db;
        public CategoryRepository(ApplicationDBContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }

      
    }
}
