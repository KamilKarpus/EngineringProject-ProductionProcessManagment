using System;

namespace PPM.Administration.Application.ReadModels
{
    public class StepsReadModel
    {
        public Guid StepId { get; set; }
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public decimal Percentage { get; set; }
        public string StepName { get; set; }
        public int MaxDaysRequiredToFinish { get; set; }
        public int Number { get; set; }
    }
}