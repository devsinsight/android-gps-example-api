using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AndroidGPSExample.Domain.Contract
{
    public interface IRepository<T> where T : class
    {
        //commands
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);

        //queries
        Task<IList<T>> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        Task<IList<T>> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        Task<T> GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
    }
}
