using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.EventDispatcher;
using PPM.Locations.Domain;
using PPM.Locations.Domain.Repositories;
using PPM.Locations.Infrastructure.Documents.Transfer;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Locations.Infrastructure.Repositories
{
    public class TransferRequestRepository : ITransferRequestRepository
    {
        private readonly IMongoRepository<TransferRequestDocument> _repository;
        private readonly IEventDispatcher _dispatcher;
        public TransferRequestRepository(IMongoRepository<TransferRequestDocument> repository,
            IEventDispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }
        public async Task Add(TransferRequest request)
        {
            await _repository.Add(request.ToDocument());
            await _dispatcher.DispatchAsync(request.DomainEvents?.ToArray());
        }

        public async Task<TransferRequest> GetById(Guid id)
        {
            var result = await _repository.Find(p => p.Id == id);
            return result?.AsEntity();
        }

        public async Task Update(TransferRequest request)
        {
            await _repository.Update(p=>p.Id == request.Id,request.ToDocument());
            await _dispatcher.DispatchAsync(request.DomainEvents?.ToArray());
        }
    }
}
