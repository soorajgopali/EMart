﻿using EMart.DA.Data;
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
        public IPlayerRepository Player { get; private set; }
        public ISpecificRepository Specific { get; private set; }
        public IBrandRepository Brand { get; private set; }
        public IEditionrepository Edition { get; private set; }
        public ILeagueRepository League { get; private set; }
        public IProductRepository Product { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public ISizeRepository Size { get; private set; }
        public IProductsizeRepository Productsize { get; private set; }
        public IUserRepository User { get; private set; }
        public IOrderRepository Order { get; private set; }

        public UnitOfWork (ApplicationDBContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            TeamType = new TeamTypeRepository(_db);
            Team = new TeamRepository(_db);
            Player = new PlayerRepository(_db);
            Specific = new SpecificRepository(_db);
            Brand = new BrandRepository(_db);
            Edition = new EditionRepository(_db);
            League = new LeageuRepository(_db);
            Product = new ProductRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            Size = new SizeRepository(_db);
            Productsize = new ProductsizeRepository(_db);
            User = new UserRepository(_db);
            Order = new OrderRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
