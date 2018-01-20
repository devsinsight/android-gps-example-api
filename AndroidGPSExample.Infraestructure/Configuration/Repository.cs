using AndroidGPSExample.Domain.Contract;
using AndroidGPSExample.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AndroidGPSExample.Repository.Configuration
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected GeoLocationDbContext _context;
        public DbSet<T> dbSet;

        public Repository(GeoLocationDbContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }

        public void Add(params T[] items)
        {
            foreach (T item in items)
                _context.Entry(item).State = EntityState.Added;
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
                _context.Entry(item).State = EntityState.Deleted;
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
                _context.Entry(item).State = EntityState.Modified;
        }

        public async Task<IList<T>> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = dbSet;

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include(navigationProperty);

            return await Task.FromResult(dbQuery.ToList());
        }

        public async Task<IList<T>> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = dbSet;

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include(navigationProperty);

            dbQuery = dbQuery.Where(where);

            return await Task.FromResult(dbQuery.ToList());
        }

        public async Task<T> GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = dbSet;

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include(navigationProperty);

            return await Task.FromResult(dbQuery.FirstOrDefault(where));
        }

    }
}
