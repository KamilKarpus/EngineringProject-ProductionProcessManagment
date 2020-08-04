using PPM.Orders.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Orders.Infrastructure.Documents.Flows
{
    public static class Extensions
    {
        public static ProductionFlowDocument ToDocument(this ProductionFlow flow)
        {
            return new ProductionFlowDocument()
            {
                Id = flow.Id,
                Name = flow.Name
            };
        }
        public static ProductionFlow AsEntity(this ProductionFlowDocument document)
        {
            return new ProductionFlow(document.Id, document.Name);
        }

    }
}
