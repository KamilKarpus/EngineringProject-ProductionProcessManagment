using System;

namespace PPM.Locations.Infrastructure.Documents.Locations
{
    public class PackageDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
    }
}