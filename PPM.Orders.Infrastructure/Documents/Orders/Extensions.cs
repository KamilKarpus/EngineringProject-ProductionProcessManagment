using PPM.Domain.ValueObject;
using PPM.Orders.Domain;
using System.Linq;

namespace PPM.Orders.Infrastructure.Documents.Orders
{
    public static class Extensions
    {
        public static OrderDocument ToDocument(this Order order)
        {
            return new OrderDocument()
            {
                Id = order.Id,
                FlowId = order.Flow.Id,
                FlowName = order.Flow.Name,
                DeliveryDate = order.DeliveryDate,
                CompanyName = order.CompanyName,
                NumberYear = order.Number != null ? order.Number.Year : 0,
                OrderNumber = order.Number != null ? order.Number.Number : 0,
                OrderedDate = order.OrderedDate,
                Status = order.Status.Id,
                Packages = order.Packages?.Select(p=>p.ToDocument()).ToList(),
            };
        }

        public static PackageDocument ToDocument(this Package package)
        {
            return new PackageDocument()
            {
                Id = package.Id,
                Height = package.Height.Value,
                Number = package.Number.Value,
                Progress = package.Progress.Value,
                Weight = package.Weight.Value,
                Width = package.Width.Value
            };
        }

        public static Package AsEntity(this PackageDocument package)
        {
            return new Package(package.Id, Kilograms.FromDecimal(package.Weight),
                Meters.FromDecimal(package.Height), Meters.FromDecimal(package.Width),
                PackageNumber.From(package.Number), Percentage.Of(package.Progress));
        }

        public static Order AsEntity(this OrderDocument order)
        {
            return new Order(order.Id, order.CompanyName, order.DeliveryDate,
                order.Packages?.Select(p => p.AsEntity()).ToHashSet(),
                new ProductionFlow(order.FlowId, order.FlowName),
                order.OrderedDate, OrderStatus.From(order.Status));
        }
    }
}
