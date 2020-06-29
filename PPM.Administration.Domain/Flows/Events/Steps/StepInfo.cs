using System;

namespace PPM.Administration.Domain.Flows.Events.Steps
{
    public class StepInfo
    {
        public Guid StepId { get; set; }
        public Guid LocationId { get; set; }
        public decimal Percentage { get; set; }
        public string StepName { get; set; }
        public int MaxDaysRequiredToFinish { get; set; }
        public int Number { get; set; }
    }
}
