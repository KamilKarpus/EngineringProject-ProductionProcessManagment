using System;

namespace PPM.Locations.Infrastructure.Documents.Locations
{
    public class PackageDocument
    {
        public Guid Id { get; set; }
        public int Progress { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public Guid OrderId { get; set; }
        public Guid FlowId { get; set; }
    }
}