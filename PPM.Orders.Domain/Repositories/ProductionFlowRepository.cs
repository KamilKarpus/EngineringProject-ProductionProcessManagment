using System;
using System.Threading.Tasks;

namespace PPM.Orders.Domain.Repositories
{
    public interface IProductionFlowRepository
    {
        Task Add(ProductionFlow flow);
        Task<ProductionFlow> GetById(Guid Id);
    }
}
