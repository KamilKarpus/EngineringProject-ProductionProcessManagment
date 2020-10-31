using MongoDB.Driver;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.Configuration.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Queries.GetLocationsAll
{
    public class GetAllLocationsQueryHandler : IQueryHandler<GetAllLocationsQuery, List<LocationShortInfo>>
    {
        private readonly IMongoRepository<LocationShortInfo> _repository;
        public GetAllLocationsQueryHandler(IMongoRepository<LocationShortInfo> repository)
        {
            _repository = repository;
        }
        public async Task<List<LocationShortInfo>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Collection.AsQueryable().ToListAsync();
        }
    }
}
