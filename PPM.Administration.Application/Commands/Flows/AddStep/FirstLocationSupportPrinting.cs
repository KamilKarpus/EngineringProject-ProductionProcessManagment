using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Repositories;
using System;

namespace PPM.Administration.Application.Commands.Flows.AddStep
{
    public class FirstLocationSupportPrinting : IFirstLocationSupportPrinting
    {
        private readonly ILocationRepository _repository;
        public bool IsSupport(Guid locationId)
        {
            var result = _repository.GetById(locationId).GetAwaiter().GetResult();
            return result.SupportPrinting;
        }
    }
}
