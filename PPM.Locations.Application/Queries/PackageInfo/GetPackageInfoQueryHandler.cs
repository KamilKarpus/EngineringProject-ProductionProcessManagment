using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.Configuration.Queries;
using PPM.Locations.Application.ReadModels;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Queries.PackageInfo
{
    public class GetPackageInfoQueryHandler : IQueryHandler<GetPackageInfoQuery, PackageInfoReadModel>
    {

        private readonly IMongoRepository<PackageInfoReadModel> _repository;
        public GetPackageInfoQueryHandler(IMongoRepository<PackageInfoReadModel> repository)
        {
            _repository = repository;
        }
        public async Task<PackageInfoReadModel> Handle(GetPackageInfoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Find(p => p.Id == request.PackageId);
        }
    }
}
