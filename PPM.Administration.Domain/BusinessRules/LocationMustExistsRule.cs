using PPM.Administration.Domain.Exceptions;
using PPM.Administration.Domain.Flows;
using PPM.Domain;
using PPM.Domain.Exceptions;
using System;

namespace PPM.Administration.Domain.BusinessRules
{
    public class LocationMustExistsRule : IBusinessRule
    {
        public PPMException Exception => new FlowException("Location must exists", ErrorCodes.LocationNotExists);

        private readonly ILocationExistence _existence;
        private readonly Guid _locationId;
        public LocationMustExistsRule(ILocationExistence existence, Guid locationId)
        {
            _existence = existence;
            _locationId = locationId;
        }
        public bool IsBroken() => !_existence.IsExists(_locationId);
    }
}
