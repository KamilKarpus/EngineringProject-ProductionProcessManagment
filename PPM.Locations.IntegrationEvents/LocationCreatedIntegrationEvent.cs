using PPM.Infrastructure.Eventbus;
using System;

namespace PPM.Locations.IntegrationEvents
{
    public class LocationCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid LocationId { get; private set; }
        public string Name { get; private set; }
        public bool SupportQR { get; private set; }
        public LocationCreatedIntegrationEvent(Guid id, DateTime occuredOn,
            Guid locationId, string name, bool supportQR) : base(id, occuredOn)
        {
            LocationId = locationId;
            Name = name;
            SupportQR = supportQR;

        }
    }
}
