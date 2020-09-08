using System;

namespace PPM.Printing.Application.Queries.GetOrderPrinting
{
    public class OrderPrintingDTO
    {
        public Guid PackageId { get; set; }
        public string FileUrl { get; set; }
    }
}
