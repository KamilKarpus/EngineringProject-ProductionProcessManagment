using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Orders.Application.Configuration.Queries;
using PPM.Orders.Application.ReadModels;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Queries.GetOrderInfo
{
    public class GetOrderInfoQueryHandler : IQueryHandler<GetOrderInfoQuery, OrderReadModel>
    {
        private readonly IMongoRepository<OrderReadModel> _repository;
        public GetOrderInfoQueryHandler(IMongoRepository<OrderReadModel> repository)
        {
            _repository = repository;
        }
        public async Task<OrderReadModel> Handle(GetOrderInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Find(p => p.Id == request.OrderId);
            return result;
        }
    }
}
