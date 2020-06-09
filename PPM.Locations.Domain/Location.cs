using PPM.Domain;
using PPM.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPM.Locations.Domain
{
    public class Location : Entity, IAggregateRoot
    {
        HashSet<Package> _packages;
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public LocationType Type { get; private set; }
        public LocationAttributes Attributes { get; private set; }
        public string Description { get; private set; }
        public Meters Height { get; private set; }
        public Meters Width { get; private set; }
        public string ShortName { get; private set; }
        public IReadOnlyCollection<Package> Packages => _packages.ToList();
        public Location(Guid id, string name, int typeId, string description, decimal width, decimal height,
            bool isExamination, bool isHandleQrCode, string shortName, HashSet<Package> packages)
        {
            Id = id;
            Name = name;
            Type = LocationType.From(typeId);
            Description = description;
            Height = Meters.FromDecimal(height);
            Width = Meters.FromDecimal(width);
            Attributes = new LocationAttributes(isExamination, isHandleQrCode);
            ShortName = shortName;
            _packages = packages;
        }

        public static Location Create(Guid id, string name, int typeId, string description, decimal width, decimal height,
            bool isExamination, bool isHandleQrCode, string shortName)
        {
            return new Location(id, name, typeId, description, width, height, isExamination, isHandleQrCode, shortName, new HashSet<Package>());
        }
    }
}
