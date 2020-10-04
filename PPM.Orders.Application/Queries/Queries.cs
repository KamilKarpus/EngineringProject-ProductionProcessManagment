using System;

namespace PPM.Orders.Application.Queries
{
    public class Queries
    {
        public static class V1
        {
            public class OrderListQuery
            {
                public int PageNumber { get; set; }
                public int PageSize { get; set; }
            }

            public class PackageInfoQuery
            {
                public Guid OrderId { get; set; }
                public Guid PackageId { get; set; }
            }
        }
    }
}
