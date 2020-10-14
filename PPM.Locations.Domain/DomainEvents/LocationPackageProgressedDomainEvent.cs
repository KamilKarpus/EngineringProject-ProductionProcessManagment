using PPM.Domain;
using System;

namespace PPM.Locations.Domain.DomainEvents
{
    public class LocationPackageProgressedDomainEvent : DomainEventBase
    {
        public Guid OrderId { get; internal set; }
        public Guid PackageId { get; internal set; }
        public int Progress { get; internal set; }
    }
}
