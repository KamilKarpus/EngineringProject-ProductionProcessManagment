using PPM.Domain;
using System;

namespace PPM.Printing.Domain.Event
{
    public class SuccessfulStatusDomainEvent : DomainEventBase
    {
        public Guid RequestId { get; internal set; }
        public int StatusId { get; internal set; }
        public string StatusName { get; internal set; }
        public DateTime ProcessedDate { get; internal set; }
        public string FileUrl { get; internal set; }
        public Guid OrderId { get; internal set; }
    }
}
