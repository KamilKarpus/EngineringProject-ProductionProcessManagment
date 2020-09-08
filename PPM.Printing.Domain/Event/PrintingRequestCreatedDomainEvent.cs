using PPM.Domain;
using System;

namespace PPM.Printing.Domain.Event
{
    public class PrintingRequestCreatedDomainEvent : DomainEventBase
    {
        public Guid RequestId { get; internal set; }
        public Guid PackageId { get; internal set; }
        public DateTime RequestDate { get; internal set; }
        public int Status { get; internal set; }
        public string StatusName { get; internal set; }
    }
}
