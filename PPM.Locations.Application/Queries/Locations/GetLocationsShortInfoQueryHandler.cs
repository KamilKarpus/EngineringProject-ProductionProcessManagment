using MongoDB.Driver;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.Configuration.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Queries.Locations
{
    public class GetLocationsShortInfoQueryHandler : IQueryHandler<GetLocationsShortInfoListQuery, List<LocationShortInfo>>
    {
        private readonly IMongoRepository<LocationShortInfo> _repository;
        public GetLocationsShortInfoQueryHandler(IMongoRepository<LocationShortInfo> repository)
        {
            _repository = repository;
        }
        public async Task<List<LocationShortInfo>> Handle(GetLocationsShortInfoListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Collection.AsQueryable().ToListAsync();
            return result;
        }
    }
}
