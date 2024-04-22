using EMart.DA.Data;
using EMart.DA.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace EMart.DA.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDBContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public T Add(T entity)
        {
            dbSet.Add(entity);
            _db.SaveChanges();

            return entity;
        }
        public T Update(T entity)
        {
            var primaryKey = _db.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();

            if (primaryKey != null)
            {
                var keyValue = entity.GetType().GetProperty(primaryKey.Name).GetValue(entity);

                var existingEntity = _db.Set<T>().Find(keyValue);

                if (existingEntity != null)
                {
                    _db.Entry(existingEntity).CurrentValues.SetValues(entity);

                    _db.SaveChanges();
                }
            }

            return entity;
        }


        public T Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(predicate);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> Execute(string sql, SqlParameter[] parameters)
        {
            return _db.Set<T>().FromSqlRaw(sql, parameters).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(predicate);
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

    }
}
