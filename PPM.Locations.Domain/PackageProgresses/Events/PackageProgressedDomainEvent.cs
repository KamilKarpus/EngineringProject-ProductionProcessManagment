using PPM.Domain;
using System;

namespace PPM.Locations.Domain.PackageProgresses.Events
{
    public class PackageProgressedDomainEvent : DomainEventBase
    {
        public Guid PackageId { get; internal set; }
        public bool IsValid { get; internal set; }
        public int Percentage { get; internal set; }
        public Guid LocationId { get; internal set; }
    }
}
