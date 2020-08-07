using PPM.Domain.ValueObject;
using System;

namespace PPM.Locations.Domain.Flow
{
    public class Step
    {
        public Guid Id { get; private set; }
        public Guid LocationId { get; private set; }
        public Percentage Percentage { get; private set; }
        public string StepName { get; private set; }
        public int MaxDaysRequiredToFinish { get; private set; }
        public int Number { get; private set; }

        public Step(Guid id, Guid locationId, int percentage, string stepName, int maxDaysRequiredToFinish, int number)
        {
            Id = id;
            LocationId = locationId;
            Percentage = Percentage.Of(percentage);
            StepName = stepName;
            MaxDaysRequiredToFinish = maxDaysRequiredToFinish;
            Number = number;
        }
    }
}
