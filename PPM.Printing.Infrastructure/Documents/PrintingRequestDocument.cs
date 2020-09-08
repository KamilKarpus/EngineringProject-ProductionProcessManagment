using System;

namespace PPM.Printing.Infrastructure.Documents
{
    public class PrintingRequestDocument
    {
        public Guid Id { get;  set; }
        public Guid PackageId { get;  set; }
        public DateTime RequestedDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public int Status { get; set; }
    }
}
