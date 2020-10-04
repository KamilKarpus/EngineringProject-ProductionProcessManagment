using System;

namespace PPM.Locations.Application.Queries
{
    public class LocationShortInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; internal set; }
        public int LocationType { get; internal set; }
    }
}
