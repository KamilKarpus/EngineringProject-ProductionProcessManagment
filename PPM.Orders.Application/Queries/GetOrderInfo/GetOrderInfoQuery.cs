using PPM.Orders.Application.Configuration.Queries;
using System;

namespace PPM.Orders.Application.Queries.GetOrderInfo
{
    public class GetOrderInfoQuery : IQuery<OrderInfoDto>
    {
        public Guid OrderId { get; set; }
    }
}
