using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Printing.Application.Configuration.Queries;
using PPM.Printing.Application.ReadModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Printing.Application.Queries.GetOrderPrinting
{
    public class GetOrderPrintingQueryHandler : IQueryHandler<GetOrderPrintingQuery, List<OrderPrintingDTO>>
    {
        private readonly IMongoRepository<PrintingRequestReadModel> _repository;
        public GetOrderPrintingQueryHandler(IMongoRepository<PrintingRequestReadModel> repository)
        {
            _repository = repository;
        }
        public async Task<List<OrderPrintingDTO>> Handle(GetOrderPrintingQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.FindMany(p => p.OrderId == request.OrderId);
            return result.Select(p => new OrderPrintingDTO()
            {
                FileUrl = p.StorageUrl,
                PackageId = p.PackageId
            }).ToList();
        }
    }
}
