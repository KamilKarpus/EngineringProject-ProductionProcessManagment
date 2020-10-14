using PPM.Locations.Domain.Flow;
using System;

namespace PPM.Locations.Domain
{
    public class RecommendedLocation
    {
        public Guid LocationId { get; private set; }
        public bool HasRecommendation { get; private set; }
        public RecommendedLocation(Step step)
        {
            if(step is null)
            {
                HasRecommendation = false;
            }
            else
            {
                LocationId = step.LocationId;
                HasRecommendation = true;
            }
        }
    }
}
