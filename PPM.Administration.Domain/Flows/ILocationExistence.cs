using System;

namespace PPM.Administration.Domain.Flows
{
    public interface ILocationExistence
    {
        bool IsExists(Guid locationId);
    }
}
