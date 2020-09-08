using System;

namespace PPM.Printing.Application.ReadModels
{
    public class PrintingRequestReadModel
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string StorageUrl { get; set; }
        public Guid OrderId { get;  set; }
    }
}
