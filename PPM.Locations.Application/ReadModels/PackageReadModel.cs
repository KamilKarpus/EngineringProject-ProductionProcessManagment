using System;

namespace PPM.Locations.Application.ReadModels
{
    public class PackageReadModel
    {
        public Guid Id { get; set; }
        public decimal Weight { get;  set; }
        public decimal Height { get;  set; }
        public decimal Width { get;  set; }
        public decimal Length { get; set; }
        public int Progress { get;  set; }
    }
}
