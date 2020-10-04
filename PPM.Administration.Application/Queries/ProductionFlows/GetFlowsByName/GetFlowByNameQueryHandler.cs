using MongoDB.Driver;
using PPM.Administration.Application.Configuration.Queries;
using PPM.Administration.Application.Queries.ProductionFlows.GetFlowsList;
using PPM.Infrastructure.DataAccess.Repositories;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using System.Threading;
using System.Threading.Tasks;
using PPM.Administration.Domain.Flows;

namespace PPM.Administration.Application.Queries.ProductionFlows.GetFlowsByName
{
    public class GetFlowByNameQueryHandler : IQueryHandler<GetFlowByNameQuery, List<ProductionFlowShortInfo>>
    {
        private readonly IMongoRepository<ProductionFlowShortInfo> _repository;
        public GetFlowByNameQueryHandler(IMongoRepository<ProductionFlowShortInfo> repository)
        {
            _repository = repository;
        }
        public async Task<List<ProductionFlowShortInfo>> Handle(GetFlowByNameQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Collection.AsQueryable().Where(p => p.Name.Contains(request.FlowName) && p.Status == Status.ReadyToUse.Id)
                                .ToListAsync();
            return result;
        }
    }
}
