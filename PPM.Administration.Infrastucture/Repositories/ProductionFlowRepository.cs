using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Repositories;
using PPM.Administration.Infrastucture.Documents.Flow;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.EventDispatcher;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Administration.Infrastucture.Repositories
{
    public class ProductionFlowRepository : IProductionFlowRepository
    {
        private readonly IMongoRepository<ProductionFlowDocument> _repository;
        private readonly IEventDispatcher _dispatcher;
        public ProductionFlowRepository(IMongoRepository<ProductionFlowDocument> repository,
            IEventDispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }
        public async Task AddAsync(ProductionFlow flow)
        {
            await _repository.Add(flow.ToDocument());
            await _dispatcher.DispatchAsync(flow.DomainEvents.ToArray());
        }

        public async Task<ProductionFlow> GetById(Guid id)
        {
            var result =  await _repository.Find(p => p.Id == id);
            return result?.ToEntity();
        }

        public async Task<ProductionFlow> GetByName(string name)
        {
            var result = await _repository.Find(p => p.Name == name);
            return result?.ToEntity();
        }

        public async Task Update(ProductionFlow flow)
        {
            await _repository.Update(p => p.Id == flow.Id, flow?.ToDocument());
            await _dispatcher.DispatchAsync(flow.DomainEvents.ToArray());
        }
    }
}
