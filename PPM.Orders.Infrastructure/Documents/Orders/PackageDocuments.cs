using System;

namespace PPM.Orders.Infrastructure.Documents.Orders
{
    public class PackageDocument
    {
        public Guid Id { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public int Number { get; set; }
        public int Progress { get;set; }
        public Guid FlowId { get; set; }
        public string FlowName { get; set; }
    }
}
