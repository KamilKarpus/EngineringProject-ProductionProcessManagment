using PPM.Locations.Domain.Flow;
using System.Linq;

namespace PPM.Locations.Infrastructure.Documents.Flow
{
    public static class Extensions
    {
        public static StepDocument ToDocument(this Step step)
           => new StepDocument()
           {
               Id = step.Id,
               MaxDaysRequiredToFinish = step.MaxDaysRequiredToFinish,
               LocationId = step.LocationId,
               StepName = step.StepName,
               Percentage = step.Percentage.Value,
               Number = step.Number
           };

        public static ProductionFlowDocument ToDocument(this ProductionFlow flow)
        {
            return new ProductionFlowDocument()
            {
                Id = flow.Id,
                Name = flow.Name,
                Steps = flow.Steps.Select(p => p.ToDocument()).ToList()
            };
        }
        public static ProductionFlow AsEntity(this ProductionFlowDocument document)
        {
            return new ProductionFlow(document.Id, document.Name, 
                document.Steps.Select(p=>p.AsEntity()).ToList());
        }
        public static Step AsEntity(this StepDocument document) 
        {
            return new Step(document.Id, document.LocationId, document.Percentage,
                document.StepName, document.MaxDaysRequiredToFinish, document.Number);
        }
    }
}
