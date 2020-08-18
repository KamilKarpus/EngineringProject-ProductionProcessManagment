using PPM.Domain.ValueObject;
using System;

namespace PPM.Orders.Domain
{
    public interface IGetFlowProgress
    {
        Percentage GetProgress(Guid locationId, Guid flowId);
    }
}
