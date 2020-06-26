using System;

namespace PPM.Administration.Domain.Flows
{
    public interface IFirstLocationSupportPrinting
    {
        bool IsSupport(Guid locationId);
    }
}
