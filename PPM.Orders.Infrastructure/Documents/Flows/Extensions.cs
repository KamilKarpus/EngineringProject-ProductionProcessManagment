using PPM.Orders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Name = flow.Name,
                Steps = flow.Steps?.Select(p => p.ToDocument()).ToList()
            };
        }
        public static ProductionFlow AsEntity(this ProductionFlowDocument document)
        {
            return new ProductionFlow(document.Id, document.Name, document.Steps?.Select(p=>p.AsEntity()).ToList());
        }

        public static StepDocument ToDocument(this Step step)
        {
            return new StepDocument()
            {
                Id = step.Id,
                LocationId = step.LocationId,
                Percentage = step.Percentage.Value
            };
        }
        public static Step AsEntity(this StepDocument document)
        {
            return new Step(document.Id, document.LocationId, document.Percentage);
        }
    }
}
