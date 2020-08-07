using System;
using System.Collections.Generic;

namespace PPM.Locations.Infrastructure.Documents.Flow
{
    public class ProductionFlowDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<StepDocument> Steps { get;  set; }
    }
}
