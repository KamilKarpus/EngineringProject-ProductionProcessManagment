using PPM.Domain.ValueObject;
using PPM.Locations.Domain.Flow;
using System;

namespace PPM.Locations.Domain
{
    public class Package
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Kilograms Weight { get; private set; }
        public ProjectFlow Flow { get; private set; }
        public Meters Height { get; private set; }
        public Meters Width { get; private set; }

        public Package(Guid id, string name, decimal weight, decimal height, decimal width)
        {
            Id = id;
            Name = name;
            Weight = Kilograms.FromDecimal(weight);
            Height = Meters.FromDecimal(height);
            Width = Meters.FromDecimal(width);
        }
    }
}