using PPM.Infrastructure.Paggination;
using PPM.Orders.Application.Configuration.Queries;
using PPM.Orders.Application.ReadModels;

namespace PPM.Orders.Application.Queries
{
    public class GetOrderListQuery : IQuery<PagedList<OrderShortViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
