﻿using PPM.Domain;
using PPM.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            LocationAttributes attributes, string shortName, HashSet<Package> packages)
        {
            Id = id;
            Name = name;
            Type = LocationType.From(typeId);
            Description = description;
            Height = Meters.FromDecimal(height);
            Width = Meters.FromDecimal(width);
            Attributes = attributes;
            ShortName = shortName;
            _packages = packages;
        }

        public static Location Create(Guid id, string name, int typeId, string description, decimal width, decimal height,
            bool handleQr, string shortName)
        {
            var attributes = new LocationAttributes(handleQr);
            return new Location(id, name, typeId, description, width, height, attributes, shortName, new HashSet<Package>());
        }
    }
}
