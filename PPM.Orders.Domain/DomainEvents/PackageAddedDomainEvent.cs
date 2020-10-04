using PPM.Domain;
using PPM.Domain.ValueObject;
using System;

namespace PPM.Orders.Domain.DomainEvents
{
    public class PackageAddedDomainEvent : DomainEventBase
    {
        public Guid OrderId { get; set; }
        public Guid PackageId { get; set; }
        public Guid FlowId { get; set; }
        public string FlowName { get; set; }
        public decimal Weight { get;  set; }
        public decimal Height { get;  set; }
        public decimal Width { get;  set; }
        public int Number { get; set; }
        public int Progress { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public decimal Length { get; internal set; }
    }
}
