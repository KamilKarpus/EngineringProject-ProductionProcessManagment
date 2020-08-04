using PPM.Infrastructure.Paggination;
using PPM.Locations.Application.Configuration.Queries;
using System.Collections.Generic;

namespace PPM.Locations.Application.Queries.Locations
{
    public class GetLocationsShortInfoListQuery : IQuery<PagedList<LocationShortInfo>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
