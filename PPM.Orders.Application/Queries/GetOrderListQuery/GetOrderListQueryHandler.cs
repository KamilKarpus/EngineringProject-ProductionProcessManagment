using MongoDB.Driver;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.Paggination;
using PPM.Orders.Application.Configuration.Queries;
using PPM.Orders.Application.ReadModels;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Queries
{
    public class GetOrderListQueryHandler : IQueryHandler<GetOrderListQuery, PagedList<OrderShortViewModel>>
    {
        private readonly IMongoRepository<OrderShortViewModel> _repository;
        public GetOrderListQueryHandler(IMongoRepository<OrderShortViewModel> repository)
        {
            _repository = repository;
        }
        public async Task<PagedList<OrderShortViewModel>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            return _repository.Collection.AsQueryable().ToPagedList(request.PageNumber, request.PageSize);
        }
    }
}
