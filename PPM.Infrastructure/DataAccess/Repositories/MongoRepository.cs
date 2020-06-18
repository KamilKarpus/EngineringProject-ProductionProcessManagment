using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PPM.Infrastructure.DataAccess.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;
        public MongoRepository(IMongoConnection connection)
        {
            _collection = connection.GetCollection<T>();
        }
        public async Task Add(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task Delete(Expression<Func<T, bool>> predicate)
        {
            await _collection.DeleteOneAsync(predicate);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.AsQueryable().AnyAsync(predicate);
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            var result = await _collection.FindAsync(predicate);
            return result.FirstOrDefault();
        }

        public async Task Update(Expression<Func<T, bool>> predicate, T entity)
        {
            await _collection.ReplaceOneAsync(predicate,entity);
        }
    }
}
