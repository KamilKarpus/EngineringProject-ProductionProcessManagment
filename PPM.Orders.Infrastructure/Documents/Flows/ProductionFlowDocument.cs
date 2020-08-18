using System;
using System.Collections.Generic;

namespace PPM.Orders.Infrastructure.Documents.Flows
{
    public class ProductionFlowDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<StepDocument> Steps { get; set; }
    }
}
