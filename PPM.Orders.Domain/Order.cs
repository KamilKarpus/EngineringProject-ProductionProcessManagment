using PPM.Domain;
using PPM.Domain.ValueObject;
using PPM.Orders.Domain.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PPM.Orders.Domain
{
    public class Order : Entity, IAggregateRoot
    {
        private HashSet<Package> _packages; 
        public Guid Id { get; private set; }
        public string CompanyName { get; private set; }
        public DateTime OrderedDate { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public OrderNumber Number { get; private set; }
        public OrderStatus Status { get; private set; }
        public ProductionFlow Flow { get; private set; }
        public IReadOnlyCollection<Package> Packages { get => _packages; }

        public Order(Guid id, string name, DateTime deliveryDate,
            HashSet<Package> packages, ProductionFlow flow, DateTime ordered, OrderStatus status)
        {
            Id = id;
            CompanyName = name;
            DeliveryDate = deliveryDate;
            _packages = packages;
            Status = status;
            OrderedDate = ordered;
            Flow = flow;

        }

        public static Order Create(Guid id, string companyName, DateTime deliveryDate,
            ProductionFlow flow)
        {
            var order = new Order(id, companyName, deliveryDate, new HashSet<Package>(), flow,
                DateTime.Now, OrderStatus.InProgress);
            var @event = new OrderCreatedDomainEvent()
            {
                OrderId = order.Id,
                StatusId = order.Status.Id,
                StatusName = order.Status.Name,
                DeliveryDate = order.DeliveryDate,
                OrderedDate = order.OrderedDate,
                CompanyName = order.CompanyName,
                FlowId = order.Flow.Id,
                FlowName = order.Flow.Name
            };
            order.AddDomainEvent(@event);
            return order;
        }

        public void AssignNumber(OrderNumber number)
        {
            Number = number;
        }

        public void AddPackage(Guid id, Kilograms weight, Meters height, Meters width)
        {
            var number = PackageNumber.First;
            if (_packages.Any())
            {
                number = _packages.Max(p => p.Number).Next();
            }
            _packages.Add(new Package(id, weight, height, width, number, Percentage.Zero));

            var @event = new PackageAddedDomainEvent()
            {
                OrderId = Id,
                PackageId = id,
                Height = height.Value,
                Weight = weight.Value,
                Progress = Percentage.Zero.Value,
                Number = number.Value,
                Width = width.Value,
            };
            AddDomainEvent(@event);
        }

    }
}
