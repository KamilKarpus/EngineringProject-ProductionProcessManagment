using PPM.Locations.Application.Configuration.Queries;
using PPM.Locations.Application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Queries.GetRecommendation
{
    public class GetRecommendationQueryHandler : IQueryHandler<GetRecommendationQuery, LocationShortInfo>
    {
        private readonly IRecommendationService _service;
        public GetRecommendationQueryHandler(IRecommendationService service)
        {
            _service = service;
        }
        public async Task<LocationShortInfo> Handle(GetRecommendationQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetRecommendation(request.PackageId); 
        }
    }
}
