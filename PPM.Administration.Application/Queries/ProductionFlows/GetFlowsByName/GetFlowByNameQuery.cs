using PPM.Administration.Application.Configuration.Queries;
using PPM.Administration.Application.Queries.ProductionFlows.GetFlowsList;
using System.Collections.Generic;

namespace PPM.Administration.Application.Queries.ProductionFlows.GetFlowsByName
{
    public class GetFlowByNameQuery : IQuery<List<ProductionFlowShortInfo>>
    {
        public string FlowName { get; set; }
    }
}
