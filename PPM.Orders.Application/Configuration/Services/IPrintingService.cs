using PPM.Orders.Application.ReadModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Configuration.Services
{
    public interface IPrintingService
    {
        Task<List<PrintingDTO>> GetbyOrderId(Guid orderId);
    }
}
