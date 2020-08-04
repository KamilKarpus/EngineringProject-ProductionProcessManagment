using PPM.Domain;
using System;

namespace PPM.Orders.Domain.DomainEvents
{
    public class PackageAddedDomainEvent : DomainEventBase
    {
        public Guid OrderId { get; set; }
        public Guid PackageId { get; set; }
        public decimal Weight { get;  set; }
        public decimal Height { get;  set; }
        public decimal Width { get;  set; }
        public int Number { get; set; }
        public int Progress { get; set; }
    }
}
