using PPM.Domain;
using PPM.Domain.Exceptions;
using PPM.Locations.Domain.Exceptions;
using System;

namespace PPM.Locations.Domain.Transfer.Rules
{
    public class LocationMustExistsRule : IBusinessRule
    {
        public PPMException Exception => new LocationException("Location not exists", ErrorCodes.LocationNotFound);
        private readonly ILocationExistance _locationExistance;
        private readonly Guid _locationId;
        public LocationMustExistsRule(ILocationExistance locationExistance,
            Guid locationId)
        {
            _locationExistance = locationExistance;
            _locationId = locationId;
        }
        public bool IsBroken()
        {
            return !_locationExistance.Exists(_locationId);
        }
    }
}
