using System;

namespace PPM.Orders.Domain
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CompanyId { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public OrderNumber Number { get; private set; }

        public Order(Guid id, Guid companyId, DateTime deliveryDate, OrderNumber number)
        {
            Id = id;
            CompanyId = companyId;
            DeliveryDate = deliveryDate;
            Number = number;
        }
    }
}
