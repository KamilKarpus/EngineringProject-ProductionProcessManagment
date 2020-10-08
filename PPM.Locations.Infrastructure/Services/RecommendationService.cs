using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.Queries;
using PPM.Locations.Application.ReadModels;
using PPM.Locations.Application.Services;
using PPM.Locations.Domain.Exceptions;
using PPM.Locations.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Locations.Infrastructure.Services
{
    public class RecommendationService : IRecommendationService
    {
        private readonly IMongoRepository<PackageInfoReadModel> _packageRepository;
        private readonly IMongoRepository<LocationReadModel> _locationRepository;
        private readonly IProductionFlowRepository _repository;
        public RecommendationService(IMongoRepository<PackageInfoReadModel> packageRepository,
            IMongoRepository<LocationReadModel> locationRepository, IProductionFlowRepository
            repository)
        {
            _packageRepository = packageRepository;
            _locationRepository = locationRepository;
            _repository = repository;
        }
        public async Task<LocationShortInfo> GetRecommendation(Guid packageId)
        {
            var package = await _packageRepository.Find(p => p.Id == packageId);
            if(package is null)
            {
                throw new LocationException("Package not found", ErrorCodes.PackageNotFound);
            }
            var flow = await _repository.GetById(package.FlowId);
            if(flow is null)
            {
                throw new LocationException("Flow not found", ErrorCodes.FlowNotFound);
            }

            var step = flow.Steps.FirstOrDefault(p => p.LocationId == package.LocationId);

            var nextStep = flow.Steps.FirstOrDefault(p => p.Number == step.Number + 1);
            if (nextStep != null)
            {
                var location = await _locationRepository.Find(p => p.Id == nextStep.LocationId);
                if (location is null)
                {
                    throw new LocationException("Location not found", ErrorCodes.LocationNotFound);
                }

                return new LocationShortInfo()
                {
                    Id = location.Id,
                    LocationType = location.LocationType,
                    Name = location.Name,
                    ShortName = location.ShortName
                };
            }
            return new LocationShortInfo();

        }
    }

}
