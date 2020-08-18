using PPM.Domain.ValueObject;
using System;

namespace PPM.Orders.Domain
{
    public class Package
    {
        public Guid Id { get; private set; }
        public Kilograms Weight {get; private set;}
        public Meters Height { get; private set; }
        public Meters Width { get; private set; }
        public PackageNumber Number { get; private set; }
        public Percentage Progress { get; private set; }
        public ProductionFlow Flow { get; private set; }

        public Package(Guid id, Kilograms weight, Meters height, Meters width, PackageNumber number, Percentage progress, ProductionFlow flow)
        {
            Id = id;
            Weight = weight;
            Height = height;
            Width = width;
            Number = number;
            Progress = progress;
            Flow = flow;
        }

        public void ChangeProgress(Percentage progress)
        {
            Progress = progress;
        }

    }
}
