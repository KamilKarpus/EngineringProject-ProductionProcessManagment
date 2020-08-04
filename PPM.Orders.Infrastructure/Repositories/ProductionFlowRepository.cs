using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.EventDispatcher;
using PPM.Orders.Domain;
using PPM.Orders.Domain.Repositories;
using PPM.Orders.Infrastructure.Documents.Flows;
using System;
using System.Threading.Tasks;

namespace PPM.Orders.Infrastructure.Repositories
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

        public async Task<ProductionFlow> GetById(Guid Id)
        {
            var result = await _repository.Find(p => p.Id == Id);
            return result?.AsEntity();
        }
    }
}
