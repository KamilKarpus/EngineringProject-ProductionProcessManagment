using PPM.Locations.Application.Configuration.Queries;
using PPM.Locations.Application.ReadModels;
using System;

namespace PPM.Locations.Application.Queries.LocationInfo
{
    public class GetLocationInfoQuery : IQuery<LocationReadModel>
    {
        public Guid LocationId { get; set; }
    }
}
