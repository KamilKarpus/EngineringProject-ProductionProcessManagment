using PPM.Domain;
using System;

namespace PPM.Orders.Domain.DomainEvents
{
    public class MovePackageDomainEvent : DomainEventBase
    {
        public Guid OrderId { get; internal set; }
        public Guid PackageId { get; internal set; }
        public int Progress { get; internal set; }
    }
}
