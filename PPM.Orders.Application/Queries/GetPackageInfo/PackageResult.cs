using System;

namespace PPM.Orders.Application.Queries.GetPackageInfo
{
    public class PackageResult
    {
        public Guid PackageId { get; set; }
        public Guid FlowId { get; set; }
        public string FlowName { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public int Number { get; set; }
        public int Progress { get; set; }
        public Guid OrderId { get; set; }
        public string CompanyName { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int OrderNumber { get; set; }
        public int OrderYear { get; set; }
        public string LocatioName { get;  set; }
        public Guid LocationId { get;  set; }
    }
}
