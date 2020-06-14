using System;
using System.Threading.Tasks;

namespace PPM.Locations.Domain.Repositories
{
    public interface ILocationsRepository
    {
        Task<Location> GetLocationById(Guid id);
        Task AddAsync(Location location);
        Task<Location> GetLocationByName(string name);
    }
}
