using PPM.Orders.Application.Configuration.Queries;
using PPM.Orders.Application.ReadModels;
using System;

namespace PPM.Orders.Application.Queries.GetOrderInfo
{
    public class GetOrderInfoQuery : IQuery<OrderReadModel>
    {
        public Guid OrderId { get; set; }
    }
}
