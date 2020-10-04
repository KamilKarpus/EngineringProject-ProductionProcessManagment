using System;
using System.Collections.Generic;

namespace PPM.Locations.Infrastructure.Documents.Locations
{
    public class LocationDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public LocationAttributesDocument Attributes { get; set; }
        public string Description { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public string ShortName { get; set; }
        public decimal Length { get; set; }
        public List<PackageDocument> Packages { get; set; }
    }
}
