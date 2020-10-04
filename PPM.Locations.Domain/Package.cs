using PPM.Domain.ValueObject;
using PPM.Locations.Domain.Flow;
using System;

namespace PPM.Locations.Domain
{
    public class Package
    {
        public Guid Id { get; private set; }
        public Kilograms Weight { get; private set; }
        public Meters Height { get; private set; }
        public Meters Width { get; private set; }
        public Percentage Progress { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Length { get; private set; }
        public Package(Guid id, decimal weight, decimal height, decimal width,
            int progress, Guid orderId, decimal length)
        {
            Id = id;
            Weight = Kilograms.FromDecimal(weight);
            Height = Meters.FromDecimal(height);
            Width = Meters.FromDecimal(width);
            Progress = Percentage.Of(progress);
            OrderId = orderId;
            Length = length;
        }
    }
}