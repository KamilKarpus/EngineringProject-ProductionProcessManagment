﻿using PPM.Domain;
using System;

namespace PPM.Locations.Domain.DomainEvents
{
    public class PackageAddedDominEvent : DomainEventBase
    {
        public Guid PackagedId { get; internal set; }
        public decimal Weight { get; internal set; }
        public decimal Height { get; internal set; }
        public decimal Width { get; internal set; }
        public int Progress { get; internal set; }
        public Guid OrderId { get; internal set; }
        public Guid LocationId { get; internal set; }
    }
}
