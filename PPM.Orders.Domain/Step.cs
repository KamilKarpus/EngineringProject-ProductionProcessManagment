using PPM.Domain.ValueObject;
using System;

namespace PPM.Orders.Domain
{
    public class Step
    {
        public Guid Id { get; private set; }
        public Guid LocationId { get; private set; }
        public Percentage Percentage { get; private set; }

        public Step(Guid id, Guid locationId, int percantege)
        {
            Id = id;
            LocationId = locationId;
            Percentage = Percentage.Of(percantege);
        }
    }
}
