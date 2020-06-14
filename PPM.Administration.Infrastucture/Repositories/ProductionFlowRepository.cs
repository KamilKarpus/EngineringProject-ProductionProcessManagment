using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Repositories;
using PPM.Administration.Infrastucture.Documents.Flow;
using PPM.Infrastructure.DataAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace PPM.Administration.Infrastucture.Repositories
{
    public class ProductionFlowRepository : IProductionFlowRepository
    {
        private readonly IMongoRepository<ProductionFlowDocument> _repository;
        public ProductionFlowRepository(IMongoRepository<ProductionFlowDocument> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(ProductionFlow flow)
        {
            await _repository.Add(flow.ToDocument());
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
    }
}
