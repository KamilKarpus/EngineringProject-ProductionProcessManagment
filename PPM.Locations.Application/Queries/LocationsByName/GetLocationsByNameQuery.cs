using PPM.Locations.Application.Configuration.Queries;
using System.Collections.Generic;

namespace PPM.Locations.Application.Queries.LocationsByName
{
    public class GetLocationsByNameQuery : IQuery<List<LocationShortInfo>>
    {
        public string Name { get; set; }
    }
}
