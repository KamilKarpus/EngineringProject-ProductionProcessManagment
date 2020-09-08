using PPM.Printing.Application.Configuration.Queries;
using System;
using System.Collections.Generic;

namespace PPM.Printing.Application.Queries.GetOrderPrinting
{
    public class GetOrderPrintingQuery : IQuery<List<OrderPrintingDTO>>
    {
        public Guid OrderId { get; set; }
    }
}
