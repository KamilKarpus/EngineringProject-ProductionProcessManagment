using PPM.Locations.Domain.Flow;
using System;
using System.Threading.Tasks;

namespace PPM.Locations.Domain.Repositories
{
    public interface IProductionFlowRepository
    {
        Task Add(ProductionFlow flow);
        Task<ProductionFlow> GetById(Guid id);
        Task Update(ProductionFlow flow);
    }
}
