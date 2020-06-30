using PPM.Administration.Application.Configuration.Queries;
using PPM.Administration.Application.ReadModels;
using PPM.Infrastructure.DataAccess.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Administration.Application.Queries.ProductionFlows.GetFlowInfo
{
    public class GetFlowInfoByIdQueryHandler : IQueryHandler<GetFlowInfoByIdQuery, ProductionFlowReadModel>
    {
        private readonly IMongoRepository<ProductionFlowReadModel> _repository;
        public GetFlowInfoByIdQueryHandler(IMongoRepository<ProductionFlowReadModel> repository)
        {
            _repository = repository;
        }
        public async Task<ProductionFlowReadModel> Handle(GetFlowInfoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Find(p => p.Id == request.Id);
        }
    }
}
