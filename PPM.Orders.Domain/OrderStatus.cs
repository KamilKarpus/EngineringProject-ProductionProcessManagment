using System.Collections.Generic;
using System.Linq;

namespace PPM.Orders.Domain
{
    public struct OrderStatus
    {
        public int Id {get; private set; }
        public string Name { get; private set; }

        public static List<OrderStatus> Statuses => new List<OrderStatus>()
        {
            InProgress, Finished
        };

        public OrderStatus(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static OrderStatus InProgress => new OrderStatus(1, nameof(InProgress));
        public static OrderStatus Finished => new OrderStatus(2, nameof(Finished));

        public static OrderStatus From(int id)
        {
            return Statuses.FirstOrDefault(p => p.Id == id);
        }
    }
}