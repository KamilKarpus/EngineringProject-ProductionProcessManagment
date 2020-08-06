using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PPM.Infrastructure.DataAccess.Repositories
{
    public interface IMongoRepository<T> where T : class
    {
        Task Update(Expression<Func<T, bool>> predicate, T entity);
        Task Add(T entity);
        Task Delete(Expression<Func<T, bool>> predicate);
        Task<T> Find(Expression<Func<T, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> FindMany(Expression<Func<T, bool>> predicate);
        IMongoCollection<T> Collection { get; }
    }
}
