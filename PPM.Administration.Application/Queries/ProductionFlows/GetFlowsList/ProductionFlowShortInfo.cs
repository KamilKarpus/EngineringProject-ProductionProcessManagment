using System;

namespace PPM.Administration.Application.Queries.ProductionFlows.GetFlowsList
{
    public class ProductionFlowShortInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsValid { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
}
