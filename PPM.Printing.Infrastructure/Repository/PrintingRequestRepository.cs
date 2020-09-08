using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.EventDispatcher;
using PPM.Printing.Domain;
using PPM.Printing.Domain.Repository;
using PPM.Printing.Infrastructure.Documents;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Printing.Infrastructure.Repository
{
    public class PrintingRequestRepository : IPrintingRequestRepository
    {
        private readonly IMongoRepository<PrintingRequestDocument> _repository;
        private readonly IEventDispatcher _eventDispatcher;
        public PrintingRequestRepository(IMongoRepository<PrintingRequestDocument> repository,
            IEventDispatcher dispatcher)
        {
            _repository = repository;
            _eventDispatcher = dispatcher;
        }
        public async Task Add(PrintingRequest request)
        {
            await _repository.Add(request.ToDocument());
            await _eventDispatcher.DispatchAsync(request.DomainEvents.ToArray());
            
        }

        public async Task<PrintingRequest> GetById(Guid id)
        {
            var result = await _repository.Find(p => p.Id == id);
            return result?.AsEntity();
        }

        public async Task Update(PrintingRequest request)
        {
            await _repository.Update(p=>p.Id == request.Id,request.ToDocument());
            await _eventDispatcher.DispatchAsync(request.DomainEvents.ToArray());
        }
    }
}
