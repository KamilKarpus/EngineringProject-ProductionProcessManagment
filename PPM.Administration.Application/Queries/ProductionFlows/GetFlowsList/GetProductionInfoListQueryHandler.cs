using MongoDB.Driver;
using PPM.Administration.Application.Configuration.Queries;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.Paggination;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Administration.Application.Queries.ProductionFlows.GetFlowsList
{
    public class GetProductionInfoListQueryHandler : IQueryHandler<GetProductionInfoListQuery, PagedList<ProductionFlowShortInfo>>
    {
        private readonly IMongoRepository<ProductionFlowShortInfo> _repository;
        public GetProductionInfoListQueryHandler(IMongoRepository<ProductionFlowShortInfo> repository)
        {
            _repository = repository;
        }
        public async Task<PagedList<ProductionFlowShortInfo>> Handle(GetProductionInfoListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Collection.AsQueryable().ToListAsync();
            return result.ToPagedList(request.PageNumber, request.PageSize);
        }
    }
}
