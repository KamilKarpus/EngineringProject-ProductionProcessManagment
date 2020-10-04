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
                DeliveryDate = order.DeliveryDate,
                CompanyName = order.CompanyName,
                NumberYear = order.Number != null ? order.Number.Year : 0,
                OrderNumber = order.Number != null ? order.Number.Number : 0,
                OrderedDate = order.OrderedDate,
                Status = order.Status.Id,
                Packages = order.Packages?.Select(p=>p.ToDocument()).ToList(),
                Description = order.Description
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
                Width = package.Width.Value,
                FlowId = package.Flow.Id,
                FlowName = package.Flow.Name,
                Length = package.Length.Value
            };
        }

        public static Package AsEntity(this PackageDocument package)
        {
            return new Package(package.Id, Kilograms.FromDecimal(package.Weight),
                Meters.FromDecimal(package.Height), Meters.FromDecimal(package.Width),
                PackageNumber.From(package.Number), Percentage.Of(package.Progress), new ProductionFlow(package.FlowId, package.FlowName),
                Meters.FromDecimal(package.Length));
        }

        public static Order AsEntity(this OrderDocument order)
        {
            return new Order(order.Id, order.CompanyName, order.DeliveryDate,
                order.Packages?.Select(p => p.AsEntity()).ToHashSet(),
                order.OrderedDate, OrderStatus.From(order.Status), order.Description);
        }
    }
}
