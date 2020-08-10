using System;

namespace PPM.Locations.Domain.Transfer
{
    public interface IGetLocationState
    {
        LocationState GetState(Guid locationId);        
    }
}
