using PPM.Domain;
using System;

namespace PPM.Orders.Domain.DomainEvents
{
    public class NumberAssignedDomainEvent : DomainEventBase
    {
        public Guid OrderId {get; set;}
        public int OrderNumber { get; set; }
        public int OrderYear { get; set; }
    }
}
