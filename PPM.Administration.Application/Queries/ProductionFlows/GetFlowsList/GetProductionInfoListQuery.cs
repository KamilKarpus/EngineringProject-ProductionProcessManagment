using PPM.Administration.Application.Configuration.Queries;
using PPM.Infrastructure.Paggination;

namespace PPM.Administration.Application.Queries.ProductionFlows.GetFlowsList
{
    public class GetProductionInfoListQuery : IQuery<PagedList<ProductionFlowShortInfo>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
