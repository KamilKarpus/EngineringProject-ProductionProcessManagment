using PPM.Locations.Application.Queries;
using System;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Services
{
    public interface IRecommendationService
    {
        Task<LocationShortInfo> GetRecommendation(Guid packageId);
    }
}
