using PPM.Domain;
using System;

namespace PPM.Printing.Domain.Event
{
    public class FailStatusDomainEvent : DomainEventBase
    {
        public Guid RequestId { get; internal set; }
        public int StatusId { get; internal set; }
        public string StatusName { get; internal set; }
    }
}
