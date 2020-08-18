using PPM.Infrastructure.Eventbus;
using System;

namespace PPM.Orders.IntegrationEvents
{
    public class PackageLocationChangeIntegrationEvent : IntegrationEvent
    {
        public PackageLocationChangeIntegrationEvent(Guid id, DateTime occouredOn, Guid packageId, 
            Guid orderId, Guid locationId) : base(id, occouredOn)
        {
            PackagedId = packageId;
            OrderId = orderId;
            LocationId = locationId;
        }
        public Guid PackagedId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid LocationId { get; private set; }

    }
}
