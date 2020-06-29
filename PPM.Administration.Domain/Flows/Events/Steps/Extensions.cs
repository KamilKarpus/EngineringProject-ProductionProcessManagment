using System.Collections.Generic;
using System.Linq;

namespace PPM.Administration.Domain.Flows.Events.Steps
{
    public static class Extensions
    {
        public static StepInfo[] ToInfoArray(this LinkedList<Step> steps)
        {
            return steps.Select(p => new StepInfo()
            {
                LocationId = p.LocationId,
                MaxDaysRequiredToFinish = p.MaxDaysRequiredToFinish,
                Number = p.Number.Value,
                Percentage = p.Percentage.Value,
                StepId = p.Id,
                StepName = p.StepName
            }).ToArray();
        }
    }
}
