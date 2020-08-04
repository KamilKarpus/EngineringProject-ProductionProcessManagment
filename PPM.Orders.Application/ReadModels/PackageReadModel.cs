using System;

namespace PPM.Orders.Application.ReadModels
{
    public class PackageReadModel
    {
        public Guid OrderId { get; set; }
        public Guid PackageId { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public int Number { get; set; }
        public int Progress { get; set; }
    }
}
