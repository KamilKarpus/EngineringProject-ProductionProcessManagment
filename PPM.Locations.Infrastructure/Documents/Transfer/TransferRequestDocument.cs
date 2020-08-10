using System;

namespace PPM.Locations.Infrastructure.Documents.Transfer
{
    public class TransferRequestDocument
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public Guid FromLocationId { get; set; }
        public Guid ToLocationId { get;  set; }
        public int StatusId { get;  set; }
        public Guid RequestedByUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
