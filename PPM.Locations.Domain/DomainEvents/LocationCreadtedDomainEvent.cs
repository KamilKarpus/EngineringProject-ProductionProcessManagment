using PPM.Domain;
using System;

namespace PPM.Locations.Domain.DomainEvents
{
    public class LocationCreatedDomainEvent : DomainEventBase
    {
        public Guid LocationId { get; set; }
        public string Name { get; set; }
        public bool SupportQR {get; set;}
        public decimal Width { get; internal set; }
        public decimal Height { get; internal set; }
        public string ShortName { get; internal set; }
        public int LocationType { get; internal set; }
        public string Description { get; internal set; }
        public decimal Length { get; internal set; }

        public LocationCreatedDomainEvent() : base()
        {
        }
    }
}
