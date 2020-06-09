using System;

namespace PPM.Administration.Infrastucture.Documents.Flow
{
    public class StepDocument
    {
        public Guid Id { get; set; }
        public LocationDocument Location { get; set; }
        public int Percentage { get; set; }
        public string StepName { get; set; }
        public int MaxDaysRequiredToFinish { get; set; }
        public int StepNumber { get; set; }
    }
}
