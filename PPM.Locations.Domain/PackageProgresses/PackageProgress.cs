using PPM.Domain;
using PPM.Domain.ValueObject;
using PPM.Locations.Domain.Flow;
using PPM.Locations.Domain.PackageProgresses.Events;
using System;

namespace PPM.Locations.Domain
{
    public class PackageProgress : Entity
    {
        public Guid Id { get; private set; }
        public Guid PackageId { get; private set; }
        public Guid LocationId { get; private set; }
        public Guid FlowId { get; private set; }
        public int CurrentStepNumber { get; private set; }
        public bool IsValid { get; private set; }
        public Percentage Percentage { get; private set; }

        public PackageProgress(Guid id, Guid packageId, Guid locationId, Guid flowId, int currentStepNumber,
            bool isValid, Percentage percentage)
        {
            Id = id;
            PackageId = packageId;
            LocationId = locationId;
            FlowId = flowId;
            CurrentStepNumber = currentStepNumber;
            IsValid = isValid;
            Percentage = percentage;
        }

        public static PackageProgress Create(Guid pacakgeId, Guid locationId, Guid flowId)
        {
            return new PackageProgress(Guid.NewGuid(), pacakgeId, locationId, flowId, 1, true, Percentage.Zero);
        }

        public void Progress(Guid nextLocation, ProductionFlow flow)
        {
            var step = flow.GetStepByNumber(CurrentStepNumber + 1);
            if (step.LocationId == nextLocation)
            {
                IsValid = true;
                CurrentStepNumber++;
                Percentage = step.Percentage;
            }
            else
            {
                IsValid = false;
            }

            var @event = new PackageProgressedDomainEvent()
            {
                PackageId = PackageId,
                IsValid = IsValid,
                Percentage = Percentage.Value,
                LocationId = step.LocationId
            };

            AddDomainEvent(@event);
        }

        public RecommendedLocation GetRecommendedLocation(ProductionFlow flow)
        {
            var step = flow.GetStepByNumber(CurrentStepNumber + 1);
            return new RecommendedLocation(step);
        }
    }
}
