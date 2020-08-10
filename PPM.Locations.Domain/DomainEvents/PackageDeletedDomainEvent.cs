using PPM.Domain;
using System;

namespace PPM.Locations.Domain.DomainEvents
{
    public class PackageDeletedDomainEvent : DomainEventBase
    {
        public Guid PackageId { get; internal set; }
        public Guid LocationId { get; internal set; }
    }
}
