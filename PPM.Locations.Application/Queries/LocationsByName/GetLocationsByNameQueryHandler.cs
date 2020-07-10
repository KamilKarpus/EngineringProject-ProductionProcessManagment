using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.Configuration.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Queries.LocationsByName
{
    public class GetLocationsByNameQueryHandler : IQueryHandler<GetLocationsByNameQuery, List<LocationShortInfo>>
    {
        private readonly IMongoRepository<LocationShortInfo> _repository;
        public GetLocationsByNameQueryHandler(IMongoRepository<LocationShortInfo> repository)
        {
            _repository = repository;
        }
        public async Task<List<LocationShortInfo>> Handle(GetLocationsByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Collection.AsQueryable().Where(p => p.Name.Contains(request.Name))
                    .ToListAsync();
            return result;
        }
    }
}
