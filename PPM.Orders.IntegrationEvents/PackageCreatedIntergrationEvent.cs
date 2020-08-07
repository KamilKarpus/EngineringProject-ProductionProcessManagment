using PPM.Infrastructure.Eventbus;
using System;

namespace PPM.Orders.IntegrationEvents
{
    public class PackageCreatedIntergrationEvent : IntegrationEvent
    {
        public Guid OrderId { get; private set; }
        public Guid PackageId { get; private set; }
        public decimal Weight { get; private set; }
        public decimal Height { get; private set; }
        public decimal Width { get; private set; }
        public int Number { get; private set; }
        public int Progress { get; private set; }
        public Guid FlowId { get;private set; }

        public PackageCreatedIntergrationEvent(Guid orderId, Guid packageId, 
            decimal weight, decimal height, decimal width, int number, int progress, 
            Guid flowId, Guid id, DateTime occuredOn) : base(id,occuredOn)
        {
            OrderId = orderId;
            PackageId = packageId;
            Weight = weight;
            Height = height;
            Width = width;
            Number = number;
            Progress = progress;
            FlowId = flowId;
        }
    }
}
