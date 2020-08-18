using System;

namespace PPM.Orders.Infrastructure.Documents.Flows
{
    public class StepDocument
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public int Percentage { get; set; }
    }
}
