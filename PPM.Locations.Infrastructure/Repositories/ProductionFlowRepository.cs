using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.EventDispatcher;
using PPM.Locations.Domain.Flow;
using PPM.Locations.Domain.Repositories;
using PPM.Locations.Infrastructure.Documents.Flow;
using System;
using System.Threading.Tasks;

namespace PPM.Locations.Infrastructure.Repositories
{
    public class ProductionFlowRepository : IProductionFlowRepository
    {
        private readonly IMongoRepository<ProductionFlowDocument> _repository;
        public ProductionFlowRepository(IMongoRepository<ProductionFlowDocument> repository)
        {
            _repository = repository;
        }
        public async Task Add(ProductionFlow flow)
        {
            await _repository.Add(flow?.ToDocument());
        }

        public async Task<ProductionFlow> GetById(Guid id)
        {
            var result = await _repository.Find(p => p.Id == id);
            return result?.AsEntity();
        }

        public async Task Upadte(ProductionFlow flow)
        {
            await _repository.Update(p => p.Id == flow.Id, flow?.ToDocument());
        }
    }
}
