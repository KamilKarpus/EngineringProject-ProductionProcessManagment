using System;

namespace PPM.Locations.Domain.Transfer
{
    public interface ILocationExistance
    {
        bool Exists(Guid locationId);
    }
}
