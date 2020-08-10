using System;
using System.Collections.Generic;

namespace PPM.Locations.Application.ReadModels
{
    public class LocationReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool SupportQR { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string ShortName { get; set; }
        public int LocationType { get;  set; }
        public string Description { get; set; }

        public List<PackageReadModel> Packages { get; set; } = new List<PackageReadModel>();
    }
}
