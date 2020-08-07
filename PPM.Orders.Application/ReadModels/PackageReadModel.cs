using System;

namespace PPM.Orders.Application.ReadModels
{
    public class PackageReadModel
    {
        public Guid PackageId { get; set; }
        public Guid FlowId { get; set; }
        public string FlowName { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public int Number { get; set; }
        public int Progress { get; set; }
    }
}
