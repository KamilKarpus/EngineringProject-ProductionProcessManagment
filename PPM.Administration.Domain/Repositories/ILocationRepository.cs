using PPM.Administration.Domain.Flows;
using System;
using System.Threading.Tasks;

namespace PPM.Administration.Domain.Repositories
{
    public interface ILocationRepository
    {
        public Task AddAsync(Location location);
        public Task<Location> GetById(Guid id);
        public Task<bool> ExistsAsync(Guid id);
    }
}
