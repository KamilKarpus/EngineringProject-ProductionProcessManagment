using PPM.Infrastructure.Eventbus;
using System;

namespace PPM.Administration.IntegrationEvents
{
    public class LocationCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid LocationId { get; private set; }
        public string Name { get; private set; }
        public LocationCreatedIntegrationEvent(Guid id, DateTime occuredOn,
            Guid locationId, string name) : base(id, occuredOn)
        {
            LocationId = locationId;
            Name = name;
        }
    }
}
