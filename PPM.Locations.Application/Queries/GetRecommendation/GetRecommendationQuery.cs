using PPM.Locations.Application.Configuration.Queries;
using System;

namespace PPM.Locations.Application.Queries.GetRecommendation
{
    public class GetRecommendationQuery : IQuery<LocationShortInfo>
    {
        public Guid PackageId { get; set; }
    }
}
