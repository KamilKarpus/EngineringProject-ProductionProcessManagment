using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.Configuration.Queries;
using PPM.Locations.Application.ReadModels;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Queries.LocationInfo
{
    public class GetLocationInfoQueryHandler : IQueryHandler<GetLocationInfoQuery, LocationReadModel>
    {
        private readonly IMongoRepository<LocationReadModel> _repository;
        public GetLocationInfoQueryHandler(IMongoRepository<LocationReadModel> repository)
        {
            _repository = repository;
        }
        public async Task<LocationReadModel> Handle(GetLocationInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Find(p => p.Id == request.LocationId);
            return result;
        }
    }
}
