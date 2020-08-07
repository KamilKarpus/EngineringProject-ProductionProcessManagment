using System;

namespace PPM.Locations.Infrastructure.Documents.Flow
{
    public class StepDocument
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public int Percentage { get; set; }
        public string StepName { get; set; }
        public int MaxDaysRequiredToFinish { get; set; }
        public int Number { get; set; }
    }
}