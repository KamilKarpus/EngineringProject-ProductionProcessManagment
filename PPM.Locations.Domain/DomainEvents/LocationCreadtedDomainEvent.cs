using PPM.Domain;
using System;

namespace PPM.Locations.Domain.DomainEvents
{
    public class LocationCreatedDomainEvent : DomainEventBase
    {
        public Guid LocationId { get; set; }
        public string Name { get; set; }

        public LocationCreatedDomainEvent() : base()
        {
        }
    }
}
