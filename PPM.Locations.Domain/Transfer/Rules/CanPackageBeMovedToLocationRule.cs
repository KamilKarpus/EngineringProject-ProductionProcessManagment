using PPM.Domain;
using PPM.Domain.Exceptions;
using PPM.Locations.Domain.Exceptions;
using System;

namespace PPM.Locations.Domain.Transfer.Rules
{
    public class CanPackageBeMovedToLocationRule : IBusinessRule
    {
        private readonly IGetLocationState _state;
        private readonly Guid _locationId;

        public CanPackageBeMovedToLocationRule(IGetLocationState state, Guid locationId)
        {
            _state = state;
            _locationId = locationId;
        }

        public PPMException Exception => new TransferException("Packaged cannot be moved to location", ErrorCodes.PackageCannotBeMoved);

        public bool IsBroken()
        {
            var state = _state.GetState(_locationId);
            if(state.Type == LocationType.OnePackageFacalitiles)
            {
                return state.PackageCount > 1;
            }
            if(state.Type == LocationType.ManyPackageFacalitiles)
            {
                return false;
            }
            return true;
        }
    }
}
