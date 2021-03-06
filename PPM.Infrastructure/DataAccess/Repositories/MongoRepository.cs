using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PPM.Infrastructure.DataAccess.Repositories
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;
        public MongoRepository(IMongoConnection connection, string collectionName)
        {
            _collection = connection.GetCollection<T>(collectionName);
        }

        public IMongoCollection<T> Collection => _collection;

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
            await _collection.ReplaceOneAsync(predicate, entity);
        }
        public async Task<List<T>> FindMany(Expression<Func<T, bool>> predicate)
        {
            var result = await _collection.FindAsync(predicate);
            return await result.ToListAsync();
        }
    }
}
