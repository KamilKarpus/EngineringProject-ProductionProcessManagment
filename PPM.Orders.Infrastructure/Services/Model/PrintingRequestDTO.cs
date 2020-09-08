using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Orders.Infrastructure.Services.Model
{
    public class PrintingRequestDTO
    {
        public Guid OrderId { get; set; }
        public PrintingRequestDTO(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
