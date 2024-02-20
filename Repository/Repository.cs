using Microsoft.EntityFrameworkCore;
using SoftTradeTEST.AppDbConetext;
using SoftTradeTEST.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradeTEST.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context _dbContext;
        internal DbSet<T> dbSet;

        public Repository(Context dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }
        public void Add(T item)
        {
            _dbContext.Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> values)
        {
            dbSet.RemoveRange(values);
        }
    }
}
