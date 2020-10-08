using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Orders.Application.Configuration.Queries;
using PPM.Orders.Application.Configuration.Services;
using PPM.Orders.Application.ReadModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Queries.GetPackageInfo
{
    public class GetPackageInfoQueryHandler : IQueryHandler<GetPackageInfoQuery, PackageResult>
    {
        private readonly IMongoRepository<OrderReadModel> _repository;
        private readonly ILocationsService _service;
        public GetPackageInfoQueryHandler(IMongoRepository<OrderReadModel> repository,
            ILocationsService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<PackageResult> Handle(GetPackageInfoQuery request, CancellationToken cancellationToken)
        {
            var order = await _repository.Find(p => p.Id == request.OrderId);
            var package = order.Packages.FirstOrDefault(p => p.PackageId == request.PackageId);
            var packageLocationInfo = await _service.GetPackageInfo(request.PackageId);
            return new PackageResult()
            {
                OrderId = order.Id,
                OrderedDate = order.OrderedDate,
                OrderNumber = order.OrderNumber,
                OrderYear = order.OrderYear,
                CompanyName = order.CompanyName,
                DeliveryDate = order.DeliveryDate,
                FlowId = package.FlowId,
                FlowName = package.FlowName,
                Height = package.Height,
                Number = package.Number,
                PackageId = package.PackageId,
                Progress = package.Progress,
                Weight = package.Weight,
                Width = package.Width,
                Length = package.Length,
                LocatioName = packageLocationInfo.LocationName,
                LocationId = packageLocationInfo.LocationId
            };
        }
    }
}
