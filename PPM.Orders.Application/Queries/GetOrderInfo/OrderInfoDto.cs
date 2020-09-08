using System;
using System.Collections.Generic;

namespace PPM.Orders.Application.Queries.GetOrderInfo
{
    public class OrderInfoDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public int OrderNumber { get; set; }
        public int OrderYear { get; set; }
        public List<Package> Packages { get; set; }
    }
    public class Package
    {
        public Guid PackageId { get; set; }
        public Guid FlowId { get; set; }
        public string FlowName { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public int Number { get; set; }
        public int Progress { get; set; }
        public string PrintingUrl { get; set; }
    }
}
