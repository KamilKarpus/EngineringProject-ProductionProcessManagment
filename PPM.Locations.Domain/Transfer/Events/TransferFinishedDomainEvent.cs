using PPM.Domain;
using System;

namespace PPM.Locations.Domain.Transfer.Events
{
    public class TransferFinishedDomainEvent : DomainEventBase
    {
        public Guid TransferId { get; internal set; }
        public Guid FromLocationId { get; internal set; }
        public Guid ToLocationId { get; internal set; }
        public Guid PackageId { get; internal set; }
        public DateTime FinishDate { get; internal set; }
        public int Status { get; internal set; }
    }
}
