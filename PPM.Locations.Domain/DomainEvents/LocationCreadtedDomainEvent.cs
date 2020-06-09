using PPM.Domain;
using System;

namespace PPM.Locations.Domain.DomainEvents
{
    public class LocationCreatedDomainEvent : DomainEventBase
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
