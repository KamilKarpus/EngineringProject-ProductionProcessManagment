using PPM.Domain.ValueObject;
using PPM.Orders.Domain;
using PPM.Orders.Domain.Repositories;
using System;
using System.Linq;

namespace PPM.Orders.Infrastructure.Domains
{
    public class GetFlowProgress : IGetFlowProgress
    {
        private readonly IProductionFlowRepository _repository;
        public GetFlowProgress(IProductionFlowRepository repository)
        {
            _repository = repository;
        }
        public Percentage GetProgress(Guid locationId, Guid flowId)
        {
            var result = _repository.GetById(flowId);
            result.Wait();
            return result.Result.Steps.FirstOrDefault(p => p.LocationId == locationId).Percentage;
        }
    }
}
