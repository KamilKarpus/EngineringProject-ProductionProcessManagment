using IdentityServer4.Models;
using IdentityServer4.Stores;
using PPM.Infrastructure.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPM.Infrastructure.GrantStore
{
    public class MongoGrantStore : IPersistedGrantStore
    {
        private readonly IMongoRepository<PersistedGrant> _mongoRepository;
        public MongoGrantStore(IMongoRepository<PersistedGrant> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }
        public async Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            return await _mongoRepository.FindMany(p => p.SubjectId == subjectId);
        }

        public async Task<PersistedGrant> GetAsync(string key)
        {
            return await _mongoRepository.Find(p => p.Key == key);
        }

        public async Task RemoveAllAsync(string subjectId, string clientId)
        {
            await _mongoRepository.Delete(p => p.SubjectId == subjectId && p.ClientId == clientId);
        }

        public async Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            await _mongoRepository.Delete(p => p.SubjectId == subjectId && p.ClientId == clientId && p.Type == type);
        }

        public async Task RemoveAsync(string key)
        {
            await _mongoRepository.Delete(p => p.Key == key);
        }

        public async Task StoreAsync(PersistedGrant grant)
        {
            await _mongoRepository.Add(grant);   
        }
    }
}
