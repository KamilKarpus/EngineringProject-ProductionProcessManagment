using PPM.Administration.Application.Configuration.Queries;
using PPM.Administration.Application.ReadModels;
using System;

namespace PPM.Administration.Application.Queries.ProductionFlows.GetFlowInfo
{
    public class GetFlowInfoByIdQuery : IQuery<ProductionFlowReadModel>
    {
        public Guid Id { get; set; }
    }
}
