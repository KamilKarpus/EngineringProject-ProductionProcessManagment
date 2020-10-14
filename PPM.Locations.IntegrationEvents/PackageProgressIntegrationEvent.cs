using PPM.Infrastructure.Eventbus;
using System;

namespace PPM.Locations.IntegrationEvents
{
    public class PackageProgressIntegrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; private set; }
        public Guid PackageId { get; private set; }
        public int Progress { get; private set; }

        public PackageProgressIntegrationEvent(Guid id, DateTime occuredOn, Guid orderId, Guid packageId, int progress) : base(id, occuredOn)
        {
            OrderId = orderId;
            PackageId = packageId;
            Progress = progress;
        }
    }
}
