using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Orders.Application.Configuration.Queries;
using PPM.Orders.Application.Configuration.Services;
using PPM.Orders.Application.ReadModels;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Queries.GetOrderInfo
{
    public class GetOrderInfoQueryHandler : IQueryHandler<GetOrderInfoQuery, OrderInfoDto>
    {
        private readonly IMongoRepository<OrderReadModel> _repository;
        private readonly IPrintingService _service;
        public GetOrderInfoQueryHandler(IMongoRepository<OrderReadModel> repository,
            IPrintingService service)
        {
            _repository = repository;
            _service = service;
        }
        public async Task<OrderInfoDto> Handle(GetOrderInfoQuery request, CancellationToken cancellationToken)
        {
            var orderInfo = await _repository.Find(p => p.Id == request.OrderId);
            var printingDto = await _service.GetbyOrderId(request.OrderId);
            var packages = orderInfo.Packages.Select(p => new Package()
            {
                FlowId = p.FlowId,
                FlowName = p.FlowName,
                Height = p.Height,
                Number = p.Number,
                PackageId = p.PackageId,
                Progress = p.Progress,
                Weight = p.Weight,
                Width = p.Width,
                PrintingUrl = printingDto.FirstOrDefault(z => z.PackageId == p.PackageId)?.FileUrl
            }).ToList();
            return new OrderInfoDto()
            {
                Id = orderInfo.Id,
                OrderedDate = orderInfo.OrderedDate,
                OrderNumber = orderInfo.OrderNumber,
                OrderYear = orderInfo.OrderYear,
                DeliveryDate = orderInfo.DeliveryDate,
                Description = orderInfo.Description,
                CompanyName = orderInfo.CompanyName,
                StatusId = orderInfo.StatusId,
                StatusName = orderInfo.StatusName,
                Packages = packages
            };
        }
    }
}
