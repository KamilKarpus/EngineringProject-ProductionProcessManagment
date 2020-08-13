using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.Configuration.Queries;
using PPM.Locations.Application.ReadModels;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Queries.Transfer
{
    public class GetTransferInfoQueryHandler : IQueryHandler<GetTransferInfoQuery, TransferReadModel>
    {
        private readonly IMongoRepository<TransferReadModel> _repository;
        public GetTransferInfoQueryHandler(IMongoRepository<TransferReadModel> repository)
        {
            _repository = repository;
        }
        public async Task<TransferReadModel> Handle(GetTransferInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Find(p => p.Id == request.TransferId);
            return result;
        }
    }
}
